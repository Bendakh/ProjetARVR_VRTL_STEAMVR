using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeRotateScript : MonoBehaviour
{
    public bool x;
    public bool y;
    public bool z;

    public int speed;

    private Rigidbody2D rb2d;
    private Vector3 rotationAxis;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(x)
        {
            rotationAxis.x = 1;
        }
        else
        {
            rotationAxis.x = 0;
        }

        if (y)
        {
            rotationAxis.y = 1;
        }
        else
        {
            rotationAxis.y = 0;
        }

        if (z)
        {
            rotationAxis.z = 1;
        }
        else
        {
            rotationAxis.z = 0;
        }
        transform.Rotate(new Vector3(rotationAxis.x * speed, rotationAxis.y * speed, rotationAxis.z * speed));
    }
}
