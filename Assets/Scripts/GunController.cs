using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = GameObject.Find("BulletSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hitInfo;

            if(Physics.Raycast(bulletSpawn.transform.position, bulletSpawn.transform.up, out hitInfo, Mathf.Infinity))
            {
                if(hitInfo.collider.gameObject.CompareTag("Target"))
                {
                    Debug.Log("TargetShot");
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
        Debug.DrawRay(bulletSpawn.transform.position, bulletSpawn.transform.up * 100.0f, Color.red);
    }
}
