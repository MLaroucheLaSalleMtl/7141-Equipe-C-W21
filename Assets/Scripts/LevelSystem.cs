using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    TrackCheckpoint track;
    public Image experienceBar;
    public Text levelText;
    public Text experienceText;
    public int expPerLevel;
    public float expBar;
    public int level;
    public int experience;
    //private int xpToNext;

    //public LevelSystem()
    //{
    //  level = 0;
    //experience = 0;
    //}
    public void Awake()
    {
        //experience = PlayerPrefs.GetInt("experience", experience);
        //level = PlayerPrefs.GetInt("level", level);
        //PlayerPrefs.Save();
        //PlayerPrefs.DeleteAll();
        level = PlayerPrefs.GetInt("level");
        experience = PlayerPrefs.GetInt("experience");
        //PlayerPrefs.SetInt("expPerLevel", expPerLevel);
        expPerLevel = PlayerPrefs.GetInt("expPerLevel");
    }
    public void AddExperience(int amount)
    {

        experience += amount;
        Debug.Log("Exp: " + experience);
        
         if (experience >= expPerLevel)
         {
             experience -= expPerLevel;
             level++;
             expPerLevel += expPerLevel;
            PlayerPrefs.SetInt("expPerLevel", expPerLevel);
             Debug.Log("Level++: " + level);
         }
       // Debug.Log("LevelUpdate: " + level);
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.SetInt("experience", experience);
            PlayerPrefs.Save();
    }

    private void Update()
    {
        Debug.Log("xpbar" + expBar); 
        levelText.text = level.ToString();
        experienceText.text = experience.ToString() + "/" + expPerLevel.ToString();
        expBar = (float)experience / expPerLevel;
        experienceBar.fillAmount = expBar;
        Debug.Log("expPerLevel: " + expPerLevel);
        Debug.Log("LevelUpdate: " + level);
        Debug.Log("Exp" + experience);
    }
};
