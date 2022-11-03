using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static int lives;
    [SerializeField] private GameObject lifePrefab;
    private GameObject[] lifeArray;
    private GameManager gameManager;
    private GameObject gm;

    void Start()
    {
        lives = 5;
        lifeArray = new GameObject[lives];
        for (int i = 0; i < lives; i++)
        {
            Vector3 location = new Vector3(-3f + (0.4f*i), 4.7f, 3);
            GameObject life = Instantiate(lifePrefab, location, Quaternion.identity);
            lifeArray[i] = life;
        }
        gm = GameObject.Find("GameManager");
        if (gm != null)
        {
            gameManager = gm.GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            RemoveLife();
        }
    }

    public void RemoveLife()
    {
        if (lives > 0)
        {
            GameObject lastElement = lifeArray[lives - 1];
            lastElement.SetActive(false);
            lives--;
        }
        else if (lives <= 0)
        {
            gameManager.GameOver();
        }
    }
}
