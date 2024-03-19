using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float x;
    private float y;
    public float sensitivity = -1f;
    private Vector3 rotate;
    public float maxYRot = 30f;
    public float minYRot = -30f;

    public float maxXRot = 30f;
    public float minXRot = -30f;

    public UIHandler uiHandler;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!uiHandler.paused)
        {
            y = Input.GetAxis("Mouse X");
            x = Input.GetAxis("Mouse Y");
            rotate = new Vector3(x, y * sensitivity, 0);
            transform.eulerAngles = transform.eulerAngles - rotate;

            LimitRot();
        }
    }

    public void LimitRot()
    {
        Vector3 playerEulerAngles = transform.rotation.eulerAngles;

        playerEulerAngles.y = (playerEulerAngles.y > 180) ? playerEulerAngles.y - 360 : playerEulerAngles.y;
        playerEulerAngles.y = Mathf.Clamp(playerEulerAngles.y, minYRot, maxYRot);

        playerEulerAngles.x = (playerEulerAngles.x > 180) ? playerEulerAngles.x - 360 : playerEulerAngles.x;
        playerEulerAngles.x = Mathf.Clamp(playerEulerAngles.x, minXRot, maxXRot);

        transform.localRotation = Quaternion.Euler(playerEulerAngles);
    }
}
