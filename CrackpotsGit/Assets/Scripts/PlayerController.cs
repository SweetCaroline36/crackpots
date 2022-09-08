using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    private GameObject[] pots = new GameObject[6];
    private Collider2D[] colliders = new Collider2D[6];
    private Collider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        pots = GameObject.FindGameObjectsWithTag("Pot");
        for (int i = 0; i < pots.Length; i++)
        {
            colliders[i] = pots[i].GetComponent<Collider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left") || Input.GetKey("a")) 
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey("right") || Input.GetKey("d"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(Input.GetKeyDown("space"))
        {
            if (playerCollider.IsTouching(colliders[2]))
            {
                pots[2].falling = true;
            }
        }
    }
}
