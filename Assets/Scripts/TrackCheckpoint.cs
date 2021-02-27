using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackCheckpoint : MonoBehaviour
{
    LevelSystem levelSystem;
    GameManager manager;
    [SerializeField] public string nameTrack;
    public int checkpointCount = 0;
    private int lastCheckpoint;
    public bool isCompleted;

    private List<Checkpoint> checkpointList;
    private int nextCheckpointIndex;
   
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
        lastCheckpoint = checkpointList.Count;
        nextCheckpointIndex = 0;
        checkpointCount = 1;
        Debug.Log("Last: " + lastCheckpoint);
    }

    public void PlayerThroughCheckpoint(Checkpoint checkpoint)
    {
        Scene scene = SceneManager.GetActiveScene();


        if (checkpointList.IndexOf(checkpoint) == nextCheckpointIndex)
        {
            Debug.Log("Good");
            nextCheckpointIndex = (nextCheckpointIndex + 1) % checkpointList.Count;
            Debug.Log("Count: " + checkpointCount);
            if (lastCheckpoint == checkpointCount)
            {
                isCompleted = true;
                Debug.Log(isCompleted);
            };
        }
        else
        {
            Debug.Log("Bad");
        }
        
    }
}
