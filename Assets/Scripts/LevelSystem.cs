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

    public void Awake()
    {
        //PlayerPrefs.Save();
        //PlayerPrefs.DeleteAll();
        level = PlayerPrefs.GetInt("level");
        experience = PlayerPrefs.GetInt("experience");
        expPerLevel = PlayerPrefs.GetInt("expPerLevel");
    }
    public void AddExperience(int amount)
    {

        experience += amount;
        
         if (experience >= expPerLevel)
         {
             experience -= expPerLevel;
             level++;
             expPerLevel += expPerLevel;
            PlayerPrefs.SetInt("expPerLevel", expPerLevel);
         }
       // Debug.Log("LevelUpdate: " + level);
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.SetInt("experience", experience);
            PlayerPrefs.Save();
    }

    private void Update()
    {
        levelText.text = level.ToString();
        experienceText.text = experience.ToString() + "/" + expPerLevel.ToString();
        expBar = (float)experience / expPerLevel;
        experienceBar.fillAmount = expBar;
    }
};
