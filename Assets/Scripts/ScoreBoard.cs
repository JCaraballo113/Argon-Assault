using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetEnemyScore(EnemyType enemyType)
    {
        switch(enemyType)
        {
            case EnemyType.Light:
                return 10;
            case EnemyType.Medium:
                return 20;
            case EnemyType.Heavy:
                return 30;
            default:
                return 0;
        }
    }

    public void ScoreHit(EnemyType enemyType)
    {
        score += GetEnemyScore(enemyType);
        scoreText.text = score.ToString();
    }
}
