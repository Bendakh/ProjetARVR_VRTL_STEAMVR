using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

    private void ResetScore()
    {
        this.score = 0;
    }

    public void IncrementScore(int value)
    {
        this.score += value;
    }

    public int GetScore()
    {
        return this.score;  
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
