using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossAttackState : EnemyBaseState
{
    public BossAttackState(EnemyStateMachine stateMachine) : base(stateMachine) { }
    private readonly int AttackAnimationHash = Animator.StringToHash("Attack Boss");
    private readonly int IdleAnimationHash = Animator.StringToHash("Idle Boss");
    private float _timer;
    private AnimatorStateInfo stateInfo;

    public override void Enter()
    {
        _stateMachine.animator.Play(AttackAnimationHash);
    }

    public override void Tick(float deltaTime)
    {
        AttackCooldownHandler(deltaTime);
        OnFinishAttackCheck();
    }

    private void AttackCooldownHandler(float deltaTime)
    {
        _timer += deltaTime;
        if (_timer >= _stateMachine.attackCooldown)
        {
            _stateMachine.animator.Play(AttackAnimationHash);
            _timer = 0f;
        }
    }

    private void OnFinishAttackCheck()
    {
        stateInfo = _stateMachine.animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1.0f)
        {
            _stateMachine.animator.Play(IdleAnimationHash);
        }

    }

    public override void Exit()
    {
        
    }
}
