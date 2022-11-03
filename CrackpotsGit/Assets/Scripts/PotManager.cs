using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PotManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject potPrefab;
    [SerializeField] private int potCount = 6;
    void Start()
    {
        for (int i = 0; i < potCount; i++)
        {
            Vector3 location = new Vector3(-2.5f + i, 3.5f, 3);
            GameObject pot = Instantiate(potPrefab, location, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
