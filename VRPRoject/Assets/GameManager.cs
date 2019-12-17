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
    public int comboCounter = 0;

    public TargetColors[] sequenceCombo;
    public int counter = 0;
    public int scoreMultiplier = 1;

    [SerializeField]
    GameObject startTarget;

    [SerializeField]
    private float gameTime = 180f;

    private float gameCounter;

    public bool gameEnd = false;
    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
        gameCounter = gameTime;
        //GameObject.FindGameObjectWithTag("Spawner").SendMessage("StartInstantiating");
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

    public bool FillAndCompare(TargetColors color)
    {
        

        this.sequenceCombo[this.counter] = color;
        if(this.sequenceCombo[this.counter] != GameObject.FindGameObjectWithTag("Generator").GetComponent<SequenceGenerator>().sequence[this.counter])
        {
            return false;
        }
        else
        {
            this.counter++;

            return true;
        }

        
    }

    public float GetTimeRemaining()
    {
        return this.gameCounter;
    }

    private void Update()
    {
        SetMultiplier();

        if(gameStarted)
            gameCounter -= Time.deltaTime;

        if (gameCounter <= 0)
        {
            gameEnd = true;
        }

        if (gameEnd && gameStarted)
        {     
            GameObject.FindGameObjectWithTag("InGameCanvas").SendMessage("SetScoreText", this.score);
            startTarget.SetActive(true);
            gameStarted = false;
        }
    }

    public void ResetGame()
    {
        ResetScore();
        gameCounter = gameTime;
        gameEnd = false;
        gameStarted = true;
}

    private void SetMultiplier()
    {
        if (comboCounter < 5)
            scoreMultiplier = 1;
        else if (comboCounter >= 5 && comboCounter < 10)
            scoreMultiplier = 2;
        else if (comboCounter >= 10)
            scoreMultiplier = 3;
    }

}
