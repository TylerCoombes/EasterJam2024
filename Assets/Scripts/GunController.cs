using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class GunController : MonoBehaviour
{
    public GameObject bulletSpawn;
    public ScoreController scoreController;
    public RabbitSpawn rabbitSpawn;
    [SerializeField]
    private float points;
    public ParticleSystem flash;

    public RaycastHit hitInfo;

    public AnimationCurve pointsCurve;
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
            //RaycastHit hitInfo;
            flash.Play();

            if(Physics.Raycast(bulletSpawn.transform.position, bulletSpawn.transform.up, out hitInfo, Mathf.Infinity))
            {
                if(hitInfo.collider.gameObject.CompareTag("Target"))
                {
                    RabbitMovement rabbitMovement = hitInfo.collider.GetComponent<RabbitMovement>();
                    rabbitMovement.Death();
                    float scoreHold = (pointsCurve.Evaluate(rabbitSpawn.level)) * (rabbitMovement.pointsPercentage);
                    scoreController.score += ((int)scoreHold);
                    scoreController.scoreText.text = scoreController.score.ToString();
                    scoreController.pointsForKillText.text = ((int)scoreHold).ToString();
                    scoreController.PointsForKill();
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
