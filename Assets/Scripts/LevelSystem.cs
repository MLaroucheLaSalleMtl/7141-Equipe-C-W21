using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    TrackCheckpoint track; //Reference vers mon Script TrackCheckpoint
    public Image experienceBar; //Pour l'image de la bar d'experience
    public Text levelText; //Pour le texte de niveau
    public Text experienceText; //Pout le texte d'experience
    public int expPerLevel = 100; //L'xp necesaire par niveau
    public float expBar; //Pour le calcul de la bar d'experience
    public int level; //Pour les niveaux
    public int experience; //Pour l'experience total

    public void Awake()
    {
        //PlayerPrefs.DeleteAll();
    }
    private void Start()
    {
        level = PlayerPrefs.GetInt("level");             //============================================
        experience = PlayerPrefs.GetInt("experience");   //Quand le script commence Get dans PlayerPrefs
        expPerLevel = PlayerPrefs.GetInt("expPerLevel"); //============================================            
    }

    public void AddExperience(int amount) //Fonction pour ajouter l'experience
    {
        experience += amount; //Ajoute l'experience
        PlayerPrefs.SetInt("experience", experience); //Set l'experience dans PlayerPrefs
        if (experience >= expPerLevel) //Si l'experience est superieur a l'xp necessaire
         {
             experience -= expPerLevel; //Enleve l'xp qui a ete necessaire pour level up
             level++; //Incremente le niveau
             expPerLevel *= 2; //double l'xp necessaire pour level up au prochain niveau
         }
       // Debug.Log("LevelUpdate: " + level);
          PlayerPrefs.SetInt("level", level); //Set le niveau dans PlayerPrefs;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("experience", experience); //Set l'experience dans PlayerPrefs
        PlayerPrefs.SetInt("expPerLevel", expPerLevel); //Set le l'xp necessaire pour le prochain level
        PlayerPrefs.Save(); //Save les PlayerPrefs
        levelText.text = level.ToString(); //Met a jour le texte de level
        experienceText.text = experience.ToString() + "/" + expPerLevel.ToString(); //Met a jour l'exp et l'exp necaissaire dans le UI
        expBar = (float)experience / expPerLevel; //Calcul pour la bar da l'UI
        experienceBar.fillAmount = expBar; //Fill l'image d'expBar
    }
};
