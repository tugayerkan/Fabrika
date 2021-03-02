using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public float mouseSensitivity = 100f;
    public Transform player;
    public Transform wheel;
    void Update()
    {
        if (GameManager.gameState == GameState.Playing)
        {

            float mouseX = Input.GetAxis("MouseX") * mouseSensitivity * Time.deltaTime;
            if (Input.GetMouseButton(0))
            {
                player.Rotate(Vector3.up * mouseX);
                wheel.Rotate(Vector3.back * mouseX);
            }
            //else if (Input.GetMouseButtonUp(0))
            //{
            //    Vector3 getWheelDefault = Vector3.Lerp(wheelDefault, wheel.transform.position, Time.deltaTime * wheelTurnTime);
            //}

        }
    }
}
