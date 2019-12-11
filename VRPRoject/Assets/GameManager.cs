﻿using System.Collections;
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

    public TargetColors[] sequenceCombo;
    public int counter = 0;

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


    // Update is called once per frame
    void Update()
    {
        
    }
}
