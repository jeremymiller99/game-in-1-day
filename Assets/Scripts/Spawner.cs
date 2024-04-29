using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnpoint;
    public GameObject[] items;

    public GameObject ri;
    public GameObject bi;
    
    public float spawnInterval;
    public float startSpeed;
    
    public int spawnCount;
    public float every10;

    void Start()
    {
        ri.GetComponent<RedItem>().speed = startSpeed;
        bi.GetComponent<BlueItem>().speed = startSpeed;
        every10 = 1;
        spawnInterval = 2;
        StartCoroutine(SpawnItems());
    }

    private void Spawn(){

        GameObject item = Instantiate(items[Random.Range(0, items.Length)]);
        item.transform.position = spawnpoint.transform.position;
    }

    private IEnumerator SpawnItems(){
        yield return new WaitForSeconds(spawnInterval);
        Spawn();
        spawnCount++;
        if(spawnCount == 10){
            every10 += 0.1f;
            spawnInterval -= 0.1f;
            ri.GetComponent<RedItem>().speed *= every10;
            bi.GetComponent<BlueItem>().speed *= every10;
            spawnCount = 0;
            Debug.Log("Speed Increased");
        }
        StartCoroutine(SpawnItems());
    }
}
