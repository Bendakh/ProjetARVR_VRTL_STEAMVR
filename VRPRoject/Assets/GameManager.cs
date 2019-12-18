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

    int score;
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

    public int bestScore = 0;


    [Header("Playable Zone")]

    [SerializeField]
    private float minXPlayableZone = -20f;

    public static float MinXPlayableZone => _instance.minXPlayableZone;

    [SerializeField]

    private float maxXPlayableZone = 20f;

    public static float MaxXPlayableZone => _instance.maxXPlayableZone;

    [SerializeField]
    private float minYPlayableZone = 5f;

    public static float MinYPlayableZone => _instance.minYPlayableZone;

    [SerializeField]

    private float maxYPlayableZone = 10f;

    public static float MaxYPlayableZone => _instance.maxYPlayableZone;

    [SerializeField]
    private float minZPlayableZone = -20f;

    public static float MinZPlayableZone => _instance.minZPlayableZone;

    [SerializeField]

    private float maxZPlayableZone = 20f;

    public static float MaxZPlayableZone => _instance.maxZPlayableZone;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("score"))
        {
            bestScore = PlayerPrefs.GetInt("score");
            GameObject.FindGameObjectWithTag("InGameCanvas").SendMessage("SetScoreText", PlayerPrefs.GetInt("score"));
        }

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
            gameCounter = 0;
        }

        if (gameEnd && gameStarted)
        {   if(score > bestScore)
            {
                PlayerPrefs.SetInt("score", score);
                PlayerPrefs.Save();
                bestScore = score;
            }
            GameObject.FindGameObjectWithTag("InGameCanvas").SendMessage("SetScoreText", this.bestScore);
            startTarget.SetActive(true);
            gameStarted = false;
        }
    }

    public void ResetGame()
    {
        ResetScore();
        comboCounter = 0;
        counter = 0;
        gameCounter = gameTime;
        gameEnd = false;
        gameStarted = true;
        GameObject.FindGameObjectWithTag("Generator").SendMessage("GenerateSequence");
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
