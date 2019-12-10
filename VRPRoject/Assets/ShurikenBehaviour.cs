using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<AxeRotateScript>().z = false;
    }
}
