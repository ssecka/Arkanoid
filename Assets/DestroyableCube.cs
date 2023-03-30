using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyableCube : MonoBehaviour
{
    
    public int hitpoints = 1;
    public GameObject gameOverScreen;
    private void OnTriggerEnter(Collider other)
    {
        this.hitpoints--;
        Debug.Log("Broken");
        if (hitpoints == 0)
        {
            Destroy(this.GameObject());
            Debug.Log("Destroyed");
            GameManager.instance.score += 10;
            if (GameManager.instance.score == 350)
            {
                gameOverScreen.SetActive(true);
            }
            
            
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
