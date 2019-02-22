using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.0f;
    [SerializeField] GameObject deathExplosion;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        gameObject.GetComponent<PlayerController>().enabled = false;
        Instantiate(deathExplosion, transform.position, Quaternion.identity);
        Invoke("ReloadScene", levelLoadDelay);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
