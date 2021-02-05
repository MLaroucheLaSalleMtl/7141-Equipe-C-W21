using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 cameraPos = new Vector3();
    public float cameraHeight = 20.0f;
    public float cameraDistance;

    void Update()
    {
        cameraPos = player.transform.position;
        cameraPos.y += cameraHeight;
        cameraPos.x += cameraDistance;
        transform.position = cameraPos;
    }
}
