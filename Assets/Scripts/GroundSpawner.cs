using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] grounds;
    int distance = 78;
    bool isSpawning = false;
    int var;

    void Start()
    {


    }

    void Update()
    {
        if (isSpawning == false)
        {
            isSpawning = true;
            StartCoroutine(SpawnGround());
        }
    }
    IEnumerator SpawnGround()
    {
        var = Random.Range(0, 3);
        Instantiate(grounds[var], new Vector3(-0.4133758f, -39.25718f, distance), Quaternion.identity);
        distance += 39;
        yield return new WaitForSeconds(3);
        isSpawning = false;
    }


}