using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //public bool isCompleted = false;
    [SerializeField] private int amountPerCheckpoint = 30;
    private int totalXP;
    private LevelSystem levelSystem;
    private Timer time;
    public TrackCheckpoint trackCheckpoint;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        levelSystem = new LevelSystem();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (trackCheckpoint.isCompleted == true)
        {   
            totalXP = (trackCheckpoint.checkpointCount - 1) * amountPerCheckpoint;
            Debug.Log("Amount" + amountPerCheckpoint);
            levelSystem.AddExperience(totalXP);
            trackCheckpoint.isCompleted = false;
        }
    }
}
