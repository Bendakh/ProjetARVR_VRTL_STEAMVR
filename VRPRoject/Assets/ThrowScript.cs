using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ThrowScript : MonoBehaviour
{
    

    [SerializeField]
    private GameObject shurikenPrefab;
    [SerializeField]
    private Transform instantiatePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject shu = Instantiate(shurikenPrefab, instantiatePosition.position, Quaternion.identity);
            shu.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 20);
        }
    }
}
