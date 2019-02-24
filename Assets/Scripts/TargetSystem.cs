using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSystem : MonoBehaviour
{
    private GameObject target;
    private GameObject targetClone;
    [SerializeField] Canvas targetCanvas;
    [SerializeField] Camera targetCamera;
    [SerializeField] Image HealthBar;
    [SerializeField] Text TargetName;
    [SerializeField] Text TargetWorth;

    [SerializeField] private Image HealthFill;

    // Start is called before the first frame update
    void Start()
    {
        HealthFill = GameObject.Find("TargetHealth").GetComponent<Image>();
        HealthBar.gameObject.SetActive(false);
        TargetName.gameObject.SetActive(false);
        TargetWorth.gameObject.SetActive(false);
        SubscribeToEnemyEvents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SubscribeToEnemyEvents()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        
        foreach(Enemy enemy in enemies)
        {
            enemy.enemyTargetedEvent += TargetHit;
        }
    }

    void TargetHit(GameObject newTarget)
    {
        if(target == null || !GameObject.ReferenceEquals(target,newTarget))
        {
            target = newTarget;
            target.GetComponent<Enemy>().enemyDeathEvent += onTargetDeath;
            SetNewTarget();
        }

        UpdateTargetUI();
        return;
    }

    void SetNewTarget()
    {
        if (targetClone != null) Destroy(targetClone);
        targetClone = Instantiate(target, targetCamera.ViewportToWorldPoint(new Vector3(-0.09f,1.1f,1f)), Quaternion.identity, targetCanvas.transform) ;
        targetClone.layer = LayerMask.NameToLayer("Targets");
        targetClone.transform.localScale = new Vector3(2, 2,2);
        Destroy(targetClone.GetComponent<Enemy>());
        Destroy(targetClone.GetComponent<HealthSystem>());
        Destroy(targetClone.GetComponent<Collider>());
        targetClone.AddComponent<Rotator>();

    }

    void UpdateTargetUI()
    {
        HealthBar.gameObject.SetActive(true);
        TargetName.gameObject.SetActive(true);
        TargetWorth.gameObject.SetActive(true);
        TargetName.text = target.GetComponent<Enemy>().GetName();
        TargetWorth.text = GetTargetWorth() + " points";

        HealthSystem hs = target.GetComponent<HealthSystem>();
        HealthFill.fillAmount = (float)hs.GetCurrentHealth() / (float)hs.GetMaxHealth();
    }

    private string GetTargetWorth()
    {
        ScoreBoard sb = FindObjectOfType<ScoreBoard>();

        return sb.GetEnemyScore(target.GetComponent<Enemy>().EnemyType).ToString();
    }

    void onTargetDeath(GameObject go)
    {
        target = null;
        Destroy(targetClone);
        HealthBar.gameObject.SetActive(false);
        TargetName.gameObject.SetActive(false);
        TargetWorth.gameObject.SetActive(false);
    }
}
