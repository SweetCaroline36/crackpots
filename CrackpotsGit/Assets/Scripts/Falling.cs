using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [SerializeField] private bool falling = false;
    [SerializeField] private float speed = 3f;
    private Vector3 startLocation;
    // Start is called before the first frame update
    void Start()
    {
        startLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    public void startFalling()
    {
        falling = true;
    }

    public void reset()
    {
        falling = false;
        transform.position = startLocation + GameManager.round * new Vector3(0, -0.6f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PotReset")
        {
            reset();
        }
    }
}
