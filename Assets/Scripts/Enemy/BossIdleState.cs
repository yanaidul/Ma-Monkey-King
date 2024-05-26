using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : EnemyBaseState
{
    public BossIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }
    private readonly int IdleAnimationHash = Animator.StringToHash("Idle Boss");


    public override void Enter()
    {
        _stateMachine.animator.Play(IdleAnimationHash);
    }

    public override void Tick(float deltaTime)
    {
        OnPlayerDetected();
    }

    public override void Exit()
    {
        
    }

    private void OnPlayerDetected()
    {
        if (_stateMachine.enemyDetector.targetInDistance == null) return;
        _stateMachine.SwitchState(new BossAttackState(_stateMachine));
    }
}
