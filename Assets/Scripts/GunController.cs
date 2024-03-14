using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Vector2 turn;
    public GameObject bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = GameObject.Find("BulletSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(turn.y, turn.x, 0);

        Shoot();
    }

    public void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hitInfo;

            if(Physics.Raycast(bulletSpawn.transform.position, bulletSpawn.transform.forward, out hitInfo, Mathf.Infinity))
            {
                if(hitInfo.collider.gameObject.CompareTag("Target"))
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
        Debug.DrawRay(bulletSpawn.transform.position, bulletSpawn.transform.up * 100.0f, Color.red);
    }
}
