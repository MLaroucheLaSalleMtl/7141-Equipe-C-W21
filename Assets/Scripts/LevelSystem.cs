using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    TrackCheckpoint track;
    private static readonly int[] expPerLevel = new int[] { 0 ,115, 600, 900, 1200, 1500, 1800, 2100, 2400, 2700, 3000 };
    public int level;
    public int experience;

    public LevelSystem()
    {
        level = 0;
        experience = 0;
    }

    public void AddExperience(int amount)
    {
        if(!IsMaxLevel()){ 
        experience += amount;
        Debug.Log(experience);
        while (!IsMaxLevel() && experience >= GetExpToNextLevel(level))
        {
            experience -= GetExpToNextLevel(level);
            level++;
            Debug.Log(level);
        }
        }
    }
    public int GetExpToNextLevel(int level)
    {
        if(level < expPerLevel.Length)
        {
            return expPerLevel[level];
        } else 
        {
            //Niveau invalide
            Debug.Log("Invalid Level: " + level);
            return 100;
        }
        
    }
    public bool IsMaxLevel()
    {
        return IsMaxLevel(level);
    }
    public bool IsMaxLevel(int level)
    {
        return level == expPerLevel.Length - 1;
    }
}
