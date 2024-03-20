using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class RabbitSpawn : MonoBehaviour
{
    public GameObject rabbitPrefab;
    public GameObject[] spawnPoints;
    public List<Transform> transforms;
    public float targetTime;
    public int whatSpawns = 0;

    public int numberOfRabbitsToSpawn = 10;
    public float spawnDelay = 2;
    public int level = 0;
    [SerializeField]
    private int rabbitsSpawned;
    public int rabbitsAlive = 0;

    public GameObject dontShootPrefab;

    public GameObject nextLevelText;
    public GameObject endGamePanel;
    public UIHandler uiHandler;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        foreach (GameObject spawnPoint in spawnPoints)
        {
            transforms.Add(spawnPoint.transform);
        }

        Invoke("BeginSpawning", 5f);

        //StartCoroutine(SpawnEnemies());
        StartCoroutine(RemoveText());
        endGamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelChange()
    {
        if (level > 5)
        {
            endGamePanel.SetActive(true);
            uiHandler.paused = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Invoke("BeginSpawning", 5f);
        }
        
        nextLevelText.GetComponent<TextMeshProUGUI>().text = "Level " + (level + 1);
        nextLevelText.SetActive(true);
        StartCoroutine("RemoveText");
    }

    private void BeginSpawning()
    {
        StartCoroutine(SpawnEnemies());
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
            Transform randomTransform = transforms[Random.Range(0, spawnPoints.Length)];

            whatSpawns = Random.Range(0, 2);
            if (whatSpawns == 0)
            {
                Instantiate(rabbitPrefab, randomTransform.position, randomTransform.rotation);
                rabbitsSpawned++;
            }
            else
            {
                Instantiate(dontShootPrefab, randomTransform.position, randomTransform.rotation);
            }
            spawnDelay = Random.Range(2, 4);
            yield return wait;

        }

        yield break;
    }

    public IEnumerator RemoveText()
    {
        yield return new WaitForSeconds(3);
        nextLevelText.SetActive(false);
    }
}
