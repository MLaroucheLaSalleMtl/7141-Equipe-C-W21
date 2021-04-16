using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Teleport : MonoBehaviour
{
    public Transform destination;//R�f�rence � l'objet vers lequel va se d�placer le joueur
    public Transform player;//R�f�rence � la position du joueur


    private void OnTriggerEnter(Collider other)
    {
        player.position = destination.transform.position;//D�place le joueur vers l'objet indiqu�
    }
}
