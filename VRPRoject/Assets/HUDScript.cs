using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
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
    }
}
