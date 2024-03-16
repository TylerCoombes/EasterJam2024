using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class RabbitMovement : MonoBehaviour
{
    public float speed = 3;
    public Vector3 startingPos;
    public float timeAlive = 0;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = gameObject.transform.position;
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
        }

        if (startingPos.x > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveLeft, speed * Time.deltaTime);
        }

        if (transform.position == moveLeft || transform.position == moveRight)
        {
            Destroy(gameObject);
        }
    }
}
