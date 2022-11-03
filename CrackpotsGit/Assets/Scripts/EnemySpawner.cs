using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float maxTime = 3;
    private float timer = 2;
    
    [SerializeField] private GameObject[] enemyPrefabs;
    private GameObject[] windows;
    private float[] laneLocations;

    // Start is called before the first frame update
    void Start()
    {
        windows = GameObject.FindGameObjectsWithTag("Window");
        laneLocations = new float[6];
        
        for (int i = 0; i < laneLocations.Length; i++)
        {
            laneLocations[i] = windows[i].transform.position.x;
        }
    }

    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newEnemy = Instantiate(enemyPrefabs[(GameManager.round%enemyPrefabs.Length)]);
            int lane = Random.Range(0, 6);
            newEnemy.transform.position = new Vector3(laneLocations[lane], -6, 2);
            Destroy(newEnemy, 15);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void killAll()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }
}
