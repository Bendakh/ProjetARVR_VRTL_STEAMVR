using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetColors
{
    YELLOW,
    BLUE,
    RED,
    GREEN,
    NULL
}

public class SequenceGenerator : MonoBehaviour
{

    

    public int sequenceLenght = 7;
    public TargetColors[] sequence;
    // Start is called before the first frame update
    void Start()
    {
        GenerateSequence();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateSequence()
    {
        //Initialisation
        TargetColors[] tempSequence = new TargetColors[sequenceLenght];
        GameManager._instance.sequenceCombo = new TargetColors[sequenceLenght];
        GameManager._instance.counter = 0;

        for(int i = 0; i < GameManager._instance.sequenceCombo.Length; i++)
        {
            GameManager._instance.sequenceCombo[i] = TargetColors.NULL;
        }

        //Generation
        for(int i = 0; i < tempSequence.Length; i++)
        {
            int temp = Random.Range(0, 4);
            switch(temp)
            {
                case 0:
                    tempSequence[i] = TargetColors.YELLOW;
                    break;
                case 1:
                    tempSequence[i] = TargetColors.BLUE;
                    break;
                case 2:
                    tempSequence[i] = TargetColors.RED;
                    break;
                case 3:
                    tempSequence[i] = TargetColors.GREEN;
                    break;
            }
        }



        this.sequence = tempSequence;
        GameObject.FindGameObjectWithTag("HUD").SendMessage("DisplaySequencePanel", this.sequence);
    }
}
