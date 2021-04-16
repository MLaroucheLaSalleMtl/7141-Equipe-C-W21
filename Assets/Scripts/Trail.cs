using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Jump jump;//Référence au script responsable du saut

    public GameObject snowboard;//Référence au snowboard

    public TrailRenderer snowTrail;//Référence au trail renderer

    public LayerMask groundLayer;//Référence au sol

    // Start is called before the first frame update
    void Start()
    {
        snowTrail = GetComponent<TrailRenderer>();//récupère le trail
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 0.25f, groundLayer))//vérifie si le snowboard/joueur touche le sol

        {
            snowTrail.emitting = true; //Active l'émission du trail
        }
        else
        {
            snowTrail.emitting = false;//Désactive l'émission du trail
        }
    }
}
