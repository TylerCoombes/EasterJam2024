using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class RabbitSpawn : MonoBehaviour
{
    public GameObject rabbitPrefab;
    public GameObject[] spawnPoints;
    public List<Vector3> transforms;
    public float targetTime;
    public int whatSpawns = 0;
    

    public GameObject dontShootPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        foreach (GameObject spawnPoint in spawnPoints)
        {
            transforms.Add(new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z));
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            Spawn();
            whatSpawns = Random.Range(0, 2);
            targetTime = Random.Range(2, 4);
            //Debug.Log(targetTime);
        }
    }

    public void Spawn()
    {
        if(whatSpawns == 0)
        {
            Instantiate(rabbitPrefab, transforms[Random.Range(0, spawnPoints.Length)], Quaternion.identity);
        }
        else
        {
            Instantiate(dontShootPrefab, transforms[Random.Range(0, spawnPoints.Length)], Quaternion.identity);
        }
    }

}
