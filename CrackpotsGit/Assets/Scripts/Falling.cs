using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public bool falling = false;
    [SerializeField] protected float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(falling)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
