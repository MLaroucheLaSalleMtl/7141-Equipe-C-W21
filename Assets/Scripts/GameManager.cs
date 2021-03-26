using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //public bool isCompleted = false;
    [SerializeField] private int amountPerCheckpoint = 30;
    private int totalXP;

    private LevelSystem levelSystem;
    private CountdownTimer time;
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

        //lvlUI.SetLevelSystem(levelSystem);
    }
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        //experienceBar.fillAmount = 0.4f;
        if (trackCheckpoint.isCompleted == true)
        {
            Scene scene = SceneManager.GetActiveScene();
            totalXP = (trackCheckpoint.checkpointCount - 1) * amountPerCheckpoint;
            levelSystem.AddExperience(totalXP);
            trackCheckpoint.isCompleted = false;
            SceneManager.LoadScene(scene.name);
        }
    }
}
