using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private TrackCheckpoint trackCheckpoints;
    private bool isColliding = false;

    private void OnTriggerEnter(Collider other)
    {

        if (isColliding) return;
        isColliding = true;
        if (other.gameObject.CompareTag("Player"))
        {
            trackCheckpoints.PlayerThroughCheckpoint(this);
            gameObject.SetActive(false);

        }
        //StartCoroutine(Reset());
    }

    public void SetTrackCheckpoints(TrackCheckpoint trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }

    //IEnumerator Reset()
    //{
    //    yield return new WaitForSeconds(1);
    //    isColliding = false;
    //}
}
