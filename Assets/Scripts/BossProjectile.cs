using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _projectileLifeSpan = 10f;

    private Vector2 direction;
    private int _currentDamage;

    public void OnLaunchProjectile(Transform target,int damage)
    {
        _currentDamage = damage;
        direction = (transform.position - target.position).normalized;
        RotateProjectile();
        Destroy(gameObject, _projectileLifeSpan);
    }


    private void RotateProjectile()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Update()
    {
        transform.Translate(direction * -_projectileSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (!collision.gameObject.TryGetComponent(out PlayerHealth playerHealth)) return;
        playerHealth.TakeDamage(_currentDamage);
        Destroy(gameObject);
    }
}
