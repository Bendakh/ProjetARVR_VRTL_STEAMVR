using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] targetList;

    private float minY;
    private float maxY;

    private float minX;
    private float maxX;

    private float minZ;
    private float maxZ;

    private float delay = 3f;
        
    // Start is called before the first frame update
    void Start()
    {
        GetPlayableZone();
        
    }

    void GetPlayableZone()
    {
        minX = GameManager.MinXPlayableZone;
        maxX = GameManager.MaxXPlayableZone;

        minY = GameManager.MinYPlayableZone;
        maxY = GameManager.MaxYPlayableZone;

        minZ = GameManager.MinZPlayableZone;
        maxZ = GameManager.MaxZPlayableZone;
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

    public void SetUpFirstTargets()
    {
        for(int i = 0; i < 3; i++)
        {
            Instantiate(targetList[0], new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
            Instantiate(targetList[1], new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
            Instantiate(targetList[2], new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
            Instantiate(targetList[3], new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
        }
        
    }
}
