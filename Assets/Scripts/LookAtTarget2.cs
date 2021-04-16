using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAtTarget2 : MonoBehaviour
{
    public Transform target; //transform du la sphere target
    private Flipping flip; //référence au script flip

    // Start is called before the first frame update
    void Start()
    {
        flip = GetComponent<Flipping>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!flip.isFlipping) //quand le joueur nest pas en train de flip
        {
            /// Référence pour m'aider : https://answers.unity.com/questions/397745/how-to-make-an-object-look-at-another-object-over.html
            Vector3 relativePos = (target.position + new Vector3(0, 0.5f, 0)) - transform.position; //Trouve la position relative entre le joueur et le target
            Quaternion rotation = Quaternion.LookRotation(relativePos); //Trouve la rotation entre c'est derniers

            Quaternion current = transform.localRotation; //Trouve la rotation actuelle
            transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * 4); //Tourne le snowboard vers la bonne direction relativement au temps (4 * delta time)

        }
    }
}
