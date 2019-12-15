using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] targetList;

    private float minY = 5f;
    private float maxY = 10f;

    private float minX = -20f;
    private float maxX = 20f;

    private float minZ = -20f;
    private float maxZ = 20f;

    private float delay = 3f;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInstantiating()
    {
        StartCoroutine("SpawnCoroutine");
    }

    IEnumerator SpawnCoroutine()
    {
        while (!GameManager._instance.gameEnd)
        {
            
                Instantiate(targetList[Random.Range(0, targetList.Length)], new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
                yield return new WaitForSeconds(delay);
            
        }
    }
}
