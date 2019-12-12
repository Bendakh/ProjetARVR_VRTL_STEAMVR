using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int scoreValue;
    [SerializeField]
    private TargetColors color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shuriken"))
        {
            
            if(!GameManager._instance.FillAndCompare(color))
            {
                Debug.Log("NO");
                GameManager._instance.comboCounter = 0;
                GameObject.FindGameObjectWithTag("Generator").SendMessage("GenerateSequence");
            }
            else
            {
                GameManager._instance.IncrementScore(scoreValue * GameManager._instance.scoreMultiplier);
                GameManager._instance.comboCounter++;
                Debug.Log("YES");
            }
            Destroy(collision.gameObject);
            if (GameManager._instance.counter == 7)
            {
                Debug.Log("Victory");
                GameObject.FindGameObjectWithTag("Generator").SendMessage("GenerateSequence");
            }
            Destroy(this.gameObject);
        }
    }
}
