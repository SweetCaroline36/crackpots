using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] public static int round = 0;
    
    private GameObject es;
    private EnemySpawner enemySpawner;

    private int roundReq = 6;
    private bool canChange = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        es = GameObject.Find("EnemySpawner");
        if (es != null)
        {
            enemySpawner = es.GetComponent<EnemySpawner>();
        }

    }

    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown("return"))
        {
            Reset();
        }
        if (Input.GetKeyDown("l"))
        {
            nextRound();
        }
        if (LifeManager.lives < 1)
        {
            GameOver();
        }
        if (Score.score % roundReq == 3)
        {
            canChange = true;
        }
        if (Score.score % roundReq == 0)
        {
            if (canChange == true)
            {
                canChange = false;
                nextRound();
            }
        }
    }
    // Update is called once per frame
    public void GameOver()
    {
        scoreCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void nextRound()
    {
        //canChange = false;
        round++;
        enemySpawner.killAll();
    }

    public void Reset()
    {
        round = 0;
        SceneManager.LoadScene(0);
    }
}