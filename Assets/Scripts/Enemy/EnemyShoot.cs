using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _projectileSpawnPos;
    [SerializeField] private int _attackDamage = 15;

    public void OnInstantiateProjectile()
    {
        if (_enemyDetector.targetInDistance == null) return;
        GameObject projectile = Instantiate(_projectile, _projectileSpawnPos.position, Quaternion.identity);
        if (!projectile.TryGetComponent(out BossProjectile bossProjectile)) return;
        bossProjectile.OnLaunchProjectile(_enemyDetector.targetInDistance, _attackDamage);
    }

}
