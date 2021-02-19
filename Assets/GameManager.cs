using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool trackCompleted = false;
    private LevelSystem levelSystem;
    private Timer time;
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
        if (trackCompleted == true)
        {
            if(time.minutes <= 0 && time.seconds <= 30)
            {
                levelSystem.AddExperience(30);   
            }
        }
    }
}
