using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float maxTime = 3;
    private float timer = 0;
    public GameObject enemy;
    private GameObject[] windows;
    private float[] laneLocations;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newEnemy = Instantiate(enemy);

        windows = GameObject.FindGameObjectsWithTag("Window");
        laneLocations = new float[6];
        
        for (int i = 0; i < laneLocations.Length; i++)
        {
            laneLocations[i] = windows[i].transform.position.x;
        }

        newEnemy.transform.position = new Vector3(laneLocations[2], -6, 0);
    }

    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newEnemy = Instantiate(enemy);
            int lane = Random.Range(0, 6);
            newEnemy.transform.position = new Vector3(laneLocations[lane], -6, 2);
            //Destroy(newEnemy, 5);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
