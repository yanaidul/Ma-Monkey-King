using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

public class EnemyHealth : HealthSystem,IDamageable
{
    private readonly int TakeHitMiniBossAnimationHash = Animator.StringToHash("Take Hit Miniboss");
    private readonly int TakeHitBossAnimationHash = Animator.StringToHash("Get Hit Boss");

    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [BoxGroup("UI Healthbar Reference")]
    [SerializeField] private TextMeshProUGUI _healthText;
    [BoxGroup("UI Healthbar Reference")]
    [SerializeField] private Image _healthBarFill;

    public bool isMiniBoss;
    public bool isBoss;
    public bool isFinalBoss;

    [ShowIf("isBoss")]
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onBossDefeatedEvent;
    
    [ShowIf("isFinalBoss")]
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onFinalBossDefeatedEvent;
    
    [ShowIf("isMiniBoss")]
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onMiniBossDefeatedEvent;

    private EnemyStateMachine _enemyStateMachine;

    public override void Start()
    {
        base.Start();
        if (!TryGetComponent(out EnemyStateMachine enemyStateMachine)) return;
        _enemyStateMachine = enemyStateMachine;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        ChangeUIHealthBarOnTakeDamage();

        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            if(isFinalBoss)
            {
                _onFinalBossDefeatedEvent.Raise();
            }
            else if (isBoss)
            {
                if (_onBossDefeatedEvent == null) return;
                _playerData.UnlockedLevel++;
                PlayerPrefs.SetInt("SavedLevel",_playerData.UnlockedLevel);
                _onBossDefeatedEvent.Raise();
            }
            else if (isMiniBoss)
            {
                _onMiniBossDefeatedEvent.Raise();
            }

        }
        else
        {
            if (isFinalBoss || isBoss)
            {
                _enemyStateMachine.animator.Play(TakeHitBossAnimationHash);
                _enemyStateMachine.SwitchState(new BossMoveState(_enemyStateMachine));
            }
            else if (isMiniBoss)
            {
                _enemyStateMachine.animator.Play(TakeHitMiniBossAnimationHash);
            }
        }
            
    }

    private void ChangeUIHealthBarOnTakeDamage()
    {
        int amount = CurrentHealth;
        _healthText.text = amount.ToString();
        _healthBarFill.fillAmount = (float)amount / _maxHealth;
    }
}
