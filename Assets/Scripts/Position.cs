using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Position : MonoBehaviour
{
    public GameObject target; //Sphere enfant
    
    RaycastHit hitInfo;//Raycast pour le sol
    private Vector3 pos = new Vector3(); //position

    /// <summary>
    /// Référence pour Ground();
    /// Jason Weimann, Snap your GameObjects to the ground with a simple hotkey,Youtube, 26 sept 2017 de https://www.youtube.com/watch?v=gLtjPxQxJPk&t=33s&ab_channel=JasonWeimann
    /// </summary>
    private void Ground()
    {
        //Trouve le sol pour attacher l'objet, vers le haut et le bas
        if (Physics.Raycast(transform.position + Vector3.up +Vector3.up ,Vector3.down, out hitInfo, 100))
        {
            pos.y = hitInfo.point.y;
        }
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ground();

        //Positionne la balle en avant du joueur à une distance constante
        transform.position = new Vector3(target.transform.position.x, pos.y, target.transform.position.z -10); 
      
    }
}
