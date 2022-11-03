using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool zigzag = false;
    [SerializeField] private GameObject enemyType;

    private LifeManager lifeManager;
    private GameObject lm;

    private bool left;
    private float windowCooldown = 0;
    private float windowCooldownMax = 1;

    void Start()
    {
        lm = GameObject.Find("LifeManager");
        if (lm != null)
        {
            lifeManager = lm.GetComponent<LifeManager>();
        }
        //GetComponent<Collider>().enabled = false;
        int lr = UnityEngine.Random.Range(0, 2);
        if (lr == 0)
        {
            left = true;
        } else
        {
            left = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= -5f)
        {
            //GetComponent<Collider>().enabled = true;
        }
        if(!zigzag) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if(left)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }else
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        if(windowCooldown > 0)
        {
            windowCooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Window")
        {
            //print("hit window");
            if (windowCooldown <= 0)
            {
                windowCooldown = windowCooldownMax;
                Destroy(gameObject);
                lifeManager.RemoveLife();
            }
        }
        if (other.gameObject.tag == "Pot")
        {
            //print("hit pot");
            Destroy(gameObject);
            Score.score++;
        }
        if(other.gameObject.tag == "Wall")
        {
            if(left)
            {
                left = false;
            } else
            {
                left = true;
            }
        }
    }

}
