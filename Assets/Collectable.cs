using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float maxZ;
    public Transform playArea;
    private Vector3 velocity;
    public Ball ball;
    public float slowScale;
    private float orignialFixedDeltaTime;

    void Awake()
    {
        orignialFixedDeltaTime = Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            if (Time.timeScale == 1 || ball.slowmoactive == false)
                {
                    Time.timeScale = slowScale;
                    Time.fixedDeltaTime = orignialFixedDeltaTime * slowScale;
                    ball.slowmoactive = true;
                }
                else
                {
                    Time.timeScale = 1;
                    Time.fixedDeltaTime = orignialFixedDeltaTime;
                }
            Destroy(this.gameObject);
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

