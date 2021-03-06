﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using VRTK;

public class ThrowScript : MonoBehaviour
{

    [SerializeField]
    AudioClip shurikenThrowAudio;
    [SerializeField]
    private GameObject shurikenPrefab;
    

    [SerializeField]
    Transform rightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            GameObject shu = Instantiate(shurikenPrefab, this.transform.position, Quaternion.identity);


            shu.GetComponent<Rigidbody>().velocity = this.transform.forward * 20;
        }
    }

    public void ThorwShuriken()
    {
        GetComponent<AudioSource>().Play();
        GameObject shu = Instantiate(shurikenPrefab, this.transform.position, Quaternion.identity);
        shu.transform.rotation = this.transform.rotation;

        shu.GetComponent<Rigidbody>().velocity = this.transform.forward * 20;
    }
}
