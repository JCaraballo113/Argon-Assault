using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IKillable
{
    [SerializeField] GameObject explosionFX;

    void Start()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        print("Particles collided with enemy " + gameObject.name);
        Kill();
    }

    public void Kill()
    {
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
