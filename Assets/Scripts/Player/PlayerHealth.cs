using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerHealth : HealthSystem, IHealable, IDamageable
{
    private readonly int TakeHitAnimationHash = Animator.StringToHash("Take Hit");

    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [BoxGroup("Events")]
    [SerializeField] protected GameEvent _onPlayerHealthChanged;
    [BoxGroup("Events")]
    [SerializeField] protected GameEventNoParam _onPlayerDeathEvent,_onRestartSceneEvent,_onDisplayGameOverUI;

    private PlayerStateMachine _playerStateMachine;

    public override void Start()
    {
        base.Start();
        if (!TryGetComponent(out PlayerStateMachine playerStateMachine)) return;
        _playerStateMachine = playerStateMachine;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _onPlayerHealthChanged.Raise(this, CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Death();
        }
        else
        {
            _playerStateMachine.Animator.Play(TakeHitAnimationHash);
            StartCoroutine(OnChangeToIdle());
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        _onPlayerHealthChanged.Raise(this, CurrentHealth);
    }

    public void Death()
    {
        _playerStateMachine.SwitchState(new PlayerDeathState(_playerStateMachine));
        _onDisplayGameOverUI.Raise();
    }

    IEnumerator OnChangeToIdle()
    {
        yield return new WaitForSeconds(0.5f);
        _playerStateMachine.SwitchState(new PlayerRoamState(_playerStateMachine));
    }
}
