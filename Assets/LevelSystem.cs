using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    private int level;
    private int experience;
    private int experienceForNextLevel = 100;

    public LevelSystem()
    {
        level = 0;
        experience = 0;
        experienceForNextLevel = 0;
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        if(experience >= experienceForNextLevel)
        {
            level++;
            experience -= experienceForNextLevel;
        }
    }
}
