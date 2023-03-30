using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

     public Transform playArea;
     public float speed;
     private float dir = 0;
     public float defaultSizeX = 3.5f;
     

     private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         dir = Input.GetAxisRaw("Horizontal");
         float limit = playArea.localScale.x * 0.5f * 10 - transform.localScale.x * 0.5f;
         float newX = transform.position.x + Time.deltaTime * speed * dir;
         float clampedX = Mathf.Clamp(newX, -limit, limit);
         transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
