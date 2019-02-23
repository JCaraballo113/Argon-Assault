using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;
    [SerializeField] EnemyType enemyType = EnemyType.Light;
    HealthSystem healthSystem;
    [SerializeField] GameObject hitFX;

    ScoreBoard scoreBoard;

    void Start()
    {
        gameObject.AddComponent<BoxCollider>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        healthSystem = GetComponent<HealthSystem>();
    }

    int GetDamageByType()
    {
        switch(enemyType)
        {
            case EnemyType.Light:
                return 20;
            case EnemyType.Medium:
                return 15;
            case EnemyType.Heavy:
                return 10;
            default:
                return 0;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage();
    }

    public void TakeDamage()
    {
        scoreBoard.ScoreHit(enemyType);
        healthSystem.Damage(GetDamageByType());
        GameObject instance = Instantiate(hitFX, transform.position, Quaternion.identity);
        instance.transform.parent = parent;

        if (healthSystem.GetCurrentHealth() <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        GameObject instance = Instantiate(explosionFX, transform.position, Quaternion.identity);
        instance.transform.parent = parent;
        Destroy(gameObject);
    }
}
