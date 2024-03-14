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
            SpawnRabbits();
            targetTime = Random.Range(3, 6);
            //Debug.Log(targetTime);
        }
    }

    public void SpawnRabbits()
    {
        Instantiate(rabbitPrefab, transforms[Random.Range(0, spawnPoints.Length)], Quaternion.identity);
    }
}
