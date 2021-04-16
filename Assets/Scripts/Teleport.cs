using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Teleport : MonoBehaviour
{
    public Transform destination;//Référence à l'objet vers lequel va se déplacer le joueur
    public Transform player;//Référence à la position du joueur


    private void OnTriggerEnter(Collider other)
    {
        player.position = destination.transform.position;//Déplace le joueur vers l'objet indiqué
    }
}
