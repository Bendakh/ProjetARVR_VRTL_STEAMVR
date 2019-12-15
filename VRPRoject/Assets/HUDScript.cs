using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    GameObject sequencePanel;
    [SerializeField]
    GameObject targetGFXPrefab;
    [SerializeField]
    TextMeshProUGUI comboText;
    [SerializeField]
    TextMeshProUGUI timeCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        this.scoreText.text = "Score : " + GameManager._instance.GetScore().ToString();
        this.comboText.text = "Combo : " + GameManager._instance.comboCounter.ToString();
        this.timeCounter.text = "Time remaining : " + Mathf.Floor(GameManager._instance.GetTimeRemaining()).ToString();
        
    }

    public void ClearSequencePanel()
    {
        int index = 0;
        GameObject[] allChildren = new GameObject[sequencePanel.transform.childCount];
        //Debug.Log(sequencePanel.transform.GetComponentsInChildren<Transform>().Length);
        foreach (Cheat c in sequencePanel.transform.GetComponentsInChildren<Cheat>())
        {
           
            allChildren[index] = c.gameObject;
            index++;
        }
       

        foreach (GameObject c in allChildren)
        {
            Destroy(c);
        }

       
    }

    public void DisplaySequencePanel(TargetColors[] sequence)
    {
        //Clean
        if(sequencePanel.transform.childCount > 0)
            ClearSequencePanel();

        //Fill
        for(int i = 0; i < sequence.Length; i++)
        {
            GameObject temp = Instantiate(targetGFXPrefab);
            switch(sequence[i])
            {
                case TargetColors.YELLOW:
                    temp.GetComponent<Image>().color = Color.yellow;
                    break;
                case TargetColors.BLUE:
                    temp.GetComponent<Image>().color = Color.blue;
                    break;
                case TargetColors.RED:
                    temp.GetComponent<Image>().color = Color.red;
                    break;
                case TargetColors.GREEN:
                    temp.GetComponent<Image>().color = Color.green;
                    break;
            }

            temp.transform.SetParent(sequencePanel.transform);
        }
    }
}
