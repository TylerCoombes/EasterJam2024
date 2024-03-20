using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    public TextMeshPro pointsForKillText;
    public TextMeshProUGUI rabbitsAliveText;

    public GunController gunController;
    public RabbitSpawn rabbitSpawn;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        rabbitsAliveText.text = "Rabbits Alive: " + rabbitSpawn.rabbitsAlive.ToString();
    }

    public void PointsForKill()
    {
        Instantiate(pointsForKillText, new Vector3(gunController.hitInfo.point.x, gunController.hitInfo.point.y + 1, gunController.hitInfo.point.z), Quaternion.identity);
    }
}
