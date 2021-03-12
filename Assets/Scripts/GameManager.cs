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
    public Text levelText;
    private string preLevelText = "Level: ";
    public Text expText;
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
    }
    // Start is called before the first frame update
    void Start()
    { 
        levelSystem.level = PlayerPrefs.GetInt("level");
        levelSystem.experience = PlayerPrefs.GetInt("experience");
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = preLevelText + levelSystem.level.ToString();
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
