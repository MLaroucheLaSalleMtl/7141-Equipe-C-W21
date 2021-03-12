using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CountdownTimer timer;
    private TrackCheckpoint trackCheckpoints;
    //private bool isColliding = false;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Snowboard"))
        {
            trackCheckpoints.PlayerThroughCheckpoint(this);
            gameObject.SetActive(false);
            trackCheckpoints.checkpointCount++;
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
