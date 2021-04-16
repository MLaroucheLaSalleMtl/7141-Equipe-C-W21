using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSettings : MonoBehaviour
{
    CinemachineFreeLook cam; //r�f�rence � la cam�ra cinemachine
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();//r�cup�re la cam�ra
    }

    // Update is called once per frame
    void Update()
    {
        //Presser 1 diminue la valeur de FieldOfView, 2 l'augmente
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam.m_Lens.FieldOfView = 50;//set le fieldOfView de la cam�ra � 50
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam.m_Lens.FieldOfView = 115;//set le fieldOfView de la cam�ra � 115
        }
    }
}
