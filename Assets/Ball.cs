using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float maxX;
    public float maxZ;
    public Transform playArea;
    public Vector3 velocity;
    public PaddleMovement paddle;
    public GameObject gameOverScreen;
    public Transform changepaddlesize;
    public Transform setslowmo;
    private float orignialFixedDeltaTime;
    public bool slowmoactive = false;
    public bool widerpaddleactive = false;

    void Awake()
    {
        orignialFixedDeltaTime = Time.fixedDeltaTime;
        Debug.Log(orignialFixedDeltaTime);
    }
    IEnumerator EndSlowMo()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 1;
        Time.fixedDeltaTime = orignialFixedDeltaTime; 
        slowmoactive = false;
        
    }
    IEnumerator EndWiderPaddle()
    {
        yield return new WaitForSeconds(6f);
        paddle.transform.localScale = new Vector3(paddle.defaultSizeX, 1, 0.5f);
        widerpaddleactive = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            float maxDist = 0.5f * other.transform.localScale.x + 0.5f * transform.localScale.x;
            float actualDist = transform.position.x - other.transform.position.x;
            float distNorm = actualDist / maxDist;
            velocity.x = distNorm * maxX;
            velocity.z *= -1;
        }

        else if (other.CompareTag("Destroyable"))
        {
            float maxDist = 0.5f * other.transform.localScale.x + 0.5f * transform.localScale.x;
            float actualDist = transform.position.x - other.transform.position.x;
            float distNorm = actualDist / maxDist;
            velocity.x = distNorm * maxX;
            velocity.z *= -1;
            int randDrop = Random.Range(1, 101);
            if (randDrop < 30)
            {
                int randDrop2 = Random.Range(1, 50);
                if (randDrop2 < 25)
                {
                 Instantiate(changepaddlesize, other.transform.position,other.transform.rotation);   
                }
                else
                {
                   Instantiate(setslowmo, other.transform.position, other.transform.rotation); 
                }

                    
            }
        } 
        else if (other.CompareTag("Wall"))
        {
            velocity.x *= -1;
        }
        else if (other.CompareTag("Roof"))
        {
            velocity.z *= -1;
            velocity.x *= 1;
        }
        else if (other.CompareTag("DeathWall"))
        {
            Debug.Log("Lost Life");
            transform.position = new Vector3(0, 0.5f, 0);
            velocity = new Vector3(0, 0, -maxZ);
            GameManager.instance.Lives--;
            
            if (GameManager.instance.Lives == 0)
            {
                Debug.Log("GameOver");
                gameOverScreen.SetActive(true);
                
                //locks the Ball in the middle of the screen
                transform.position = new Vector3(0, 0, 0);
                velocity = new Vector3(0, 0, 0);
            }
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

        if (slowmoactive == true)
        {
            StartCoroutine(EndSlowMo());
        }

        if (widerpaddleactive == true)
        {
            StartCoroutine(EndWiderPaddle());
        }
       
       
    }
}
