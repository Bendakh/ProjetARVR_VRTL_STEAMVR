using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InGameCanvas : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    public void LaunchGame()
    {
        Debug.Log("Begin");
    }

    public void SetScoreText(int score)
    {
        scoreText.text = "Best score : " + score.ToString();
    }
}
