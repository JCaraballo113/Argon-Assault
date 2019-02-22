using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IKillable
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;
    [SerializeField] EnemyType enemyType = EnemyType.Light;

    ScoreBoard scoreBoard;

    void Start()
    {
        gameObject.AddComponent<BoxCollider>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Kill();
    }

    public void Kill()
    {
        GameObject instance = Instantiate(explosionFX, transform.position, Quaternion.identity);
        instance.transform.parent = parent;
        scoreBoard.ScoreHit(enemyType);
        Destroy(gameObject);
    }
}
