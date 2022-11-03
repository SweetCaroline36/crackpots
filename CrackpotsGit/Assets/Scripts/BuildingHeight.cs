using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHeight : MonoBehaviour
{
    private Vector2 startLocation;
    void Start()
    {
        startLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startLocation + GameManager.round * new Vector2(0, -0.6f);
    }
}
