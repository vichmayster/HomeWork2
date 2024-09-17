using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    [SerializeField] GameObject prefab; 
    [SerializeField] GameObject[] spawnPoints; 

    void Start()
    {
        StartCoroutine(Spawn());
        AppleLogic.Collacted += HandleAppleCollacted;
    }

    void OnDestroy()
    {
       
        AppleLogic.Collacted -= HandleAppleCollacted;
    }

    void HandleAppleCollacted()
    {
        TriggerSpawn();
    }

    void TriggerSpawn()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;

        GameObject apple = Instantiate(prefab, spawnPosition, Quaternion.identity);

        yield return null; 
    }

   
}