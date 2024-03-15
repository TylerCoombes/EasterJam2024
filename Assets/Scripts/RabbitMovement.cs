using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RabbitMovement : MonoBehaviour
{
    public float speed = 3;
    public Vector3 startingPos;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(startingPos.x < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startingPos.x + 35, startingPos.y + 0, startingPos.z + 0), speed * Time.deltaTime);
        }

        if (startingPos.x > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startingPos.x - 35, startingPos.y + 0, startingPos.z + 0), speed * Time.deltaTime);
        }
    }
}
