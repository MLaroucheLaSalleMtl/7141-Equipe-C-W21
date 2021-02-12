using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackCheckpoint : MonoBehaviour
{
    [SerializeField] public string nameTrack;

    //private Transform PlayerTransform;
    //public Transform Restart;

    private List<Checkpoint> checkpointList;
    private int nextCheckpointIndex;
    private void Start()
    {
        
    }

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find(nameTrack);
        
        checkpointList = new List<Checkpoint>();
        
        foreach(Transform checkpointTransform in checkpointsTransform)
        {
            Checkpoint checkpoint = checkpointTransform.GetComponent<Checkpoint>();

            checkpoint.SetTrackCheckpoints(this);
            
            checkpointList.Add(checkpoint);
        }

        nextCheckpointIndex = 0;
    }

    public void PlayerThroughCheckpoint(Checkpoint checkpoint)
    {
        if(checkpointList.IndexOf(checkpoint) == nextCheckpointIndex)
        {
            Debug.Log("Good");
            nextCheckpointIndex = (nextCheckpointIndex + 1) % checkpointList.Count;
        }
        else
        {
            Debug.Log("Bad");
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
