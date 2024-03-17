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

    public int numberOfRabbitsToSpawn = 10;
    public float spawnDelay = 2;
    [SerializeField]
    private int level = 0;
    [SerializeField]
    private int rabbitsSpawned;
    public int rabbitsAlive = 0;
 

    

    public GameObject dontShootPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        foreach (GameObject spawnPoint in spawnPoints)
        {
            transforms.Add(new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z));
        }

        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
       /* targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            Spawn();
            whatSpawns = Random.Range(0, 2);
            targetTime = Random.Range(2, 4);
            //Debug.Log(targetTime);
        }*/
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

    public IEnumerator SpawnEnemies()
    {
        Debug.Log("Started Spawning");
        level++;
        rabbitsSpawned = 0;
        rabbitsAlive = numberOfRabbitsToSpawn;

        WaitForSeconds wait = new WaitForSeconds(spawnDelay);

        while (rabbitsSpawned < numberOfRabbitsToSpawn)
        {
            whatSpawns = Random.Range(0, 2);
            if (whatSpawns == 0)
            {
                Instantiate(rabbitPrefab, transforms[Random.Range(0, spawnPoints.Length)], Quaternion.identity);
                rabbitsSpawned++;
            }
            else
            {
                Instantiate(dontShootPrefab, transforms[Random.Range(0, spawnPoints.Length)], Quaternion.identity);
            }
            spawnDelay = Random.Range(2, 4);
            yield return wait;

        }

        yield break;
    }
}
