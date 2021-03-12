using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    TrackCheckpoint track;
    private static readonly int[] expPerLevel = new int[] { 250, 500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000, 5500 };
    public int level;
    public int experience;

    //public LevelSystem()
    //{
      //  level = 0;
        //experience = 0;
    //}

    public void AddExperience(int amount)
    {

        experience += amount;
        Debug.Log("Exp: " + experience);

         if (experience >= GetExpToNextLevel(level))
         {
             experience -= GetExpToNextLevel(level);
             level++;
             Debug.Log("Level++: " + level);
         }
        Debug.Log("LevelUpdate: " + level);
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.SetInt("experience", experience);
            PlayerPrefs.Save();
    }

    public int GetExpToNextLevel(int level)
    {
        if (level <= expPerLevel.Length)
        {
            return expPerLevel[level];
        }
        else
        {
            //Niveau invalide
            Debug.Log("Invalid Level: " + level);
            return 30;
        }

    }

    private void Update()
    {
        //levelText.text = preLevelText + level.ToString();

        //Debug.Log("LevelUpdate: " + level);
    }
};
