using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown("return"))
        {
            Reset();
        }
    }
    // Update is called once per frame
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}