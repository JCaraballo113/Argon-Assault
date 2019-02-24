using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("General")]
    [SerializeField] EnemyType enemyType = EnemyType.Light;
    [SerializeField] Transform parent;

    [Header("Effects")]
    [SerializeField] GameObject explosionFX;
    [SerializeField] GameObject hitFX;

    HealthSystem healthSystem;
    ScoreBoard scoreBoard;

    public EnemyType EnemyType { get => enemyType; set => enemyType = value; }

    public event Action<GameObject> enemyDeathEvent;
    public event Action<GameObject> enemyTargetedEvent;

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

    public string GetName()
    {
        switch (enemyType)
        {
            case EnemyType.Light:
                return "Light Cruiser";
            case EnemyType.Medium:
                return "Medium Cruiser";
            case EnemyType.Heavy:
                return "Heavy Cruiser";
            default:
                return "Ship";
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage();
    }

    public void TakeDamage()
    {
        healthSystem.Damage(GetDamageByType());
        GameObject instance = Instantiate(hitFX, transform.position, Quaternion.identity);
        instance.transform.parent = parent;

        if (enemyTargetedEvent != null) enemyTargetedEvent(gameObject);

        if (healthSystem.GetCurrentHealth() <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        if(enemyDeathEvent != null) enemyDeathEvent(gameObject);

        GameObject instance = Instantiate(explosionFX, transform.position, Quaternion.identity);
        instance.transform.parent = parent;
        scoreBoard.ScoreHit(enemyType);
        Destroy(gameObject);
    }
}
