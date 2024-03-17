using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletSpawn;
    public ScoreController scoreController;
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
                    RabbitMovement rabbitMovement = hitInfo.collider.GetComponent<RabbitMovement>();
                    rabbitMovement.Death();
                    Debug.Log(rabbitMovement.timeAlive);
                    scoreController.score += 10 - ((int)rabbitMovement.timeAlive);
                    scoreController.scoreText.text = scoreController.score.ToString();
                    Debug.Log(scoreController.score);
                }

                if(hitInfo.collider.gameObject.CompareTag("DontShoot"))
                {
                    Destroy(hitInfo.collider.gameObject);
                    scoreController.score -= 10;
                    scoreController.scoreText.text = scoreController.score.ToString();
                }
            }
        }
        Debug.DrawRay(bulletSpawn.transform.position, bulletSpawn.transform.up * 100.0f, Color.red);
    }
}
