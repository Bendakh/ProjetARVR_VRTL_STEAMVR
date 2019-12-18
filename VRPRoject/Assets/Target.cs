using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{


    [SerializeField]
    private int scoreValue;
    [SerializeField]
    private TargetColors color;
    [SerializeField]
    private float moveSpeed = 20;

    private float minX;
    private float maxX;

    private float minZ;
    private float maxZ;

    Vector3[] directions = {Vector3.right, Vector3.left, Vector3.forward, Vector3.back};

    Vector3 moveHorDirection;

    private bool moveCircularBool;
    private void Awake()
    {
        moveCircularBool = (Random.value > 0.5f);
    }
    // Start is called before the first frame update
    void Start()
    {
        GetPlayableZone();
        if(!moveCircularBool)
            InvokeRepeating("MoveHor",0,3);
    }

    void GetPlayableZone()
    {
        minX = GameManager.MinXPlayableZone;
        maxX = GameManager.MaxXPlayableZone;

        minZ = GameManager.MinZPlayableZone;
        maxZ = GameManager.MaxZPlayableZone;
    }

    // Update is called once per frame
    void Update()
    {

        if (!moveCircularBool)
        {
            GetComponent<Rigidbody>().velocity = moveHorDirection * (moveSpeed * 0.5f);

            RegulateBounds();

            if (transform.position.x == minX || transform.position.x == maxZ || transform.position.z == minZ || transform.position.z == maxZ)
            {
                MoveHor();
            }
        }

        else
        {
            MoveCircular();
        }
       

        if (GameManager._instance.gameEnd)
            Destroy(this.gameObject);

        
    }

    private void MoveCircular()
    {
        transform.RotateAround(new Vector3(0, this.transform.position.y, 0), Vector3.up, (moveSpeed * 1.5f) * Time.deltaTime);
    }

    private void MoveHor()
    {
        moveHorDirection = directions[Random.Range(0, directions.Length)];
        
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shuriken"))
        {
            GameManager._instance.PlayHitSound();

            if (!GameManager._instance.FillAndCompare(color))
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
                GameManager._instance.IncreaseTime();
                Debug.Log("Victory");
                GameObject.FindGameObjectWithTag("Generator").SendMessage("GenerateSequence");
            }
            Destroy(this.gameObject);
        }
    }

    private void RegulateBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, minX, maxX);
        pos.z = Mathf.Clamp(transform.position.z, minZ, maxZ);
        transform.position = pos;
    }
}
