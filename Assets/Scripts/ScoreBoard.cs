using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int score = 0;
    Dictionary<EnemyType, int> enemyValues = new Dictionary<EnemyType, int>
    {
        {EnemyType.Light, 10 },
        {EnemyType.Medium, 20 },
        {EnemyType.Heavy, 30 }
    };

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreHit(EnemyType enemyType)
    {
        score += enemyValues[enemyType];
        scoreText.text = score.ToString();
    }
}
