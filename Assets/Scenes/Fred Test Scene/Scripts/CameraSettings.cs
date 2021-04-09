using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSettings : MonoBehaviour
{
    CinemachineFreeLook cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
        cam.m_CommonLens = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam.m_Lens.FieldOfView = 50;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam.m_Lens.FieldOfView = 115;
        }
    }
}
