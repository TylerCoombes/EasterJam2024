using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class RabbitMovement : MonoBehaviour
{
    public float speed;
    public Vector3 startingPos;
    public float timeAlive = 0;
    private float distanceTraveled;

    public float pointsPercentage;

    public AnimationCurve speedCurve;

    private RabbitSpawn rabbitSpawn;
    // Start is called before the first frame update
    void Start()
    {
        rabbitSpawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<RabbitSpawn>();
        startingPos = gameObject.transform.position;

        speed = speedCurve.Evaluate(rabbitSpawn.level);
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;

        Vector3 moveLeft = new Vector3(startingPos.x - 35, startingPos.y + 0, startingPos.z + 0);
        Vector3 moveRight = new Vector3(startingPos.x + 35, startingPos.y + 0, startingPos.z + 0);

        if (startingPos.x < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveRight, speed * Time.deltaTime);
            distanceTraveled = Vector3.Distance(gameObject.transform.position, moveRight);
            Debug.Log(distanceTraveled);
        }

        if (startingPos.x > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveLeft, speed * Time.deltaTime);
            distanceTraveled = Vector3.Distance(gameObject.transform.position, moveLeft);
            Debug.Log(distanceTraveled);
        }

        if (transform.position == moveLeft || transform.position == moveRight)
        {
            Death();
        }
    }

    public void Death()
    {
        if (gameObject.CompareTag("Target"))
        {
            pointsPercentage = distanceTraveled / 35; 

            Debug.Log("Death" + pointsPercentage);
            rabbitSpawn.rabbitsAlive--;
            if (rabbitSpawn.rabbitsAlive == 0)
            {
                rabbitSpawn.StartCoroutine(rabbitSpawn.SpawnEnemies());
                rabbitSpawn.LevelChange();
            }
        }
        Destroy(gameObject);
    }
}
