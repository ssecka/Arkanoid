using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePaddleSize : MonoBehaviour
{
    public float maxZ;
    public Transform playArea;
    private Vector3 velocity;
    public PaddleMovement paddle;
    public Ball ball;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            if (ball.widerpaddleactive == false)
            {
              paddle.transform.localScale += new Vector3(paddle.defaultSizeX * 1.2f, 0f, 0f);
              ball.widerpaddleactive = true;
              Destroy(this.gameObject);  
            }
        }

        else if (other.CompareTag("DeathWall"))
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, -maxZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        float maxZPosition = playArea.localScale.z * 0.5f * 10 + 2;
        if (transform.position.z > maxZPosition)
        {
            transform.position = new Vector3(0, 0.5f, 0);
            velocity = new Vector3(0, 0, -maxZ);
        }
    }
}