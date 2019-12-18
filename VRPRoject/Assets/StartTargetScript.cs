using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTargetScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shuriken"))
        {
            GameManager._instance.PlayHitSound();

            GameObject.FindGameObjectWithTag("Spawner").SendMessage("SetUpFirstTargets");          
            GameObject.FindGameObjectWithTag("Spawner").SendMessage("StartInstantiating");         
            this.gameObject.SetActive(false);
            GameManager._instance.ResetGame();
            
        }
    }
}
