using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    public TextMeshPro pointsForKillText;

    public List<GameObject> pointsList;

    public GunController gunController;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject text in pointsList)
        {
            StartCoroutine(WaitToDespawn());
            Destroy(text);
        }
    }

    public void PointsForKill()
    {
        Instantiate(pointsForKillText, new Vector3(gunController.hitInfo.point.x, gunController.hitInfo.point.y + 1, gunController.hitInfo.point.z), Quaternion.identity);
        pointsList.Add(pointsForKillText.gameObject);
        StartCoroutine(WaitToDespawn());
    }

    public IEnumerator WaitToDespawn()
    {
        Debug.Log("StartingCoroutine");

        yield return new WaitForSeconds(1.5f);
    }
}
