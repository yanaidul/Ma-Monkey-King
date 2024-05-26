using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveState : EnemyBaseState
{
    public BossMoveState(EnemyStateMachine stateMachine) : base(stateMachine) { }
    private readonly int MoveAnimationHash = Animator.StringToHash("Move Boss");
    private BossTargetPos _bosTargetPos;
    private Transform _nextTargetPos;

    public override void Enter()
    {
        _stateMachine.animator.Play(MoveAnimationHash);
        if (!_stateMachine.TryGetComponent(out BossTargetPos bosTargetPos)) return;
        _bosTargetPos = bosTargetPos;
        _nextTargetPos = _bosTargetPos.ReturnRandomPosition();
    }

    public override void Tick(float deltaTime)
    {
        HandleMove();
    }

    public override void Exit()
    {
        
    }

    private void HandleMove()
    {
        if (_stateMachine.enemyDetector.targetInDistance != null)
        {
            float distance = Vector2.Distance(_stateMachine.transform.position, _nextTargetPos.position);

            if (distance > _stateMachine.stoppingDistance)
            {
                MoveToDestinatedPosition(_nextTargetPos.position);
                FlipSpriteHandler(_nextTargetPos.position);
            }
            else
            {
                FlipSpriteHandler(_stateMachine.enemyDetector.targetInDistance.transform.position);
                _stateMachine.enemyRb.velocity = Vector2.zero;
                OnBackToAttackState();
            }
        }
    }
    private void FlipSpriteHandler(Vector3 destinatedPos)
    {
        if (_stateMachine.transform.position.x > destinatedPos.x)
        {
            _stateMachine.enemySprite.flipX = true;
        }
        else
        {
            _stateMachine.enemySprite.flipX = false;
        }
    }

    private void MoveToDestinatedPosition(Vector3 destinatedPos)
    {
        Vector2 direction = (destinatedPos - _stateMachine.transform.position).normalized;
        if (_stateMachine.isGroundEnemy)
        {
            _stateMachine.enemyRb.velocity = new Vector3(direction.x, 0, 0) * _stateMachine.moveSpeed * 1.5f;
        }
        else
        {
            _stateMachine.enemyRb.velocity = direction * _stateMachine.moveSpeed * 1.5f;
        }
    }

    private void OnBackToAttackState()
    {
        _stateMachine.SwitchState(new BossAttackState(_stateMachine));
    }
}
