using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    
    [SerializeField] private GameObject lanePrefab;
    [SerializeField] private int laneCount = 6;
    void Start()
    {
        for (int i = 0; i < laneCount; i++)
        {
            Vector3 location = new Vector3(-2.5f + i, 4.0f, 3);
            GameObject lane = Instantiate(lanePrefab, location, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
