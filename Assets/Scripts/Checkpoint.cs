using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CountdownTimer timer; //Reference vers CountdownTimer
    private TrackCheckpoint trackCheckpoints; //Reference vers TrackCheckpoint

    private void OnTriggerEnter(Collider other)//TriggerEnter pour mes drapeaux
    {
        if (other.gameObject.CompareTag("Player"))//Si lobject a le tag Player
        {
            trackCheckpoints.PlayerThroughCheckpoint(this); //Passe dans le checkpoint prend le gameObject
            gameObject.SetActive(false); //Desactive le gameobject
            trackCheckpoints.checkpointCount++; //Incremente mon compteur
            timer.totalTime += 3f; //Ajoute du temps au timer
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoint trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints; //Pour faire reference a lobject quon va ajouter a la liste de checkpoint
    }

    //IEnumerator Reset()
    //{
    //   yield return new WaitForSeconds(0.01f);
    //  isColliding = false;
    //}
}
