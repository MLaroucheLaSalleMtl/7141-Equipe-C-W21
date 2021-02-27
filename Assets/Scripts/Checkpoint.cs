using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private TrackCheckpoint trackCheckpoints;
    //private bool isColliding = false;

    private void OnTriggerEnter(Collider other)
    {

        //if (isColliding) return;
        //isColliding = true;
        if (other.gameObject.CompareTag("Snowboard"))
        {
            trackCheckpoints.PlayerThroughCheckpoint(this);
            gameObject.SetActive(false);
            trackCheckpoints.checkpointCount++;
            //StartCoroutine(Reset());
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoint trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }

    //IEnumerator Reset()
    //{
    //   yield return new WaitForSeconds(0.01f);
    //  isColliding = false;
    //}
}
