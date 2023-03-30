using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int Lives = 3;

    public TMP_Text textMeshScore;
    public TMP_Text textMeshLives;
    public static GameManager instance;


    // Start is called before the first frame update

    public int P1Score
    {
        set
        {
            score = value;
            updateScoreDisplay();
        }
        get
        {
            return score;
        }
    }

    public int RemainingLives
    {
        set
        {
            Lives = value;
            updateLivesDisplay();
        }
        get
        {
            return Lives;
        }
    }

    void updateScoreDisplay()
    {
        textMeshScore.text = "Score : " + score;
    }

    void updateLivesDisplay()
    {
        textMeshLives.text = "Lives : " + Lives;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        textMeshScore.text = "Score : " + score;
        textMeshLives.text = "Lives : " + Lives;
    }
}
