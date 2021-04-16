using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;



public class Pause : MonoBehaviour
{
    public JumpingPoints jumpingPoints;//référence au script JumpingPoints pour store des points
    public LevelSystem levelSystem;//référence au script LevelSystem pour récupérer la valeur du niveau
    public Text pointsText;//référence au texte du UI pour les points
    public GameObject pauseMenu; //Élément du UI pour le menu pause 
    public GameObject pointCounterUI; //Élément du UI pour pour le point counter
    public GameObject levelUI; //Élément du UI pour le niveau/XP
    public GameObject optionsUI;//Élément du UI pour les settings dans le pause menu
    public GameObject pauseMainUI;//Élément du UI englobant tout ce qui est en "pause"
    public bool isPaused = false; //Bool permettant de pause/unpause le jeu

    public Renderer snowboard;//réf au snowboard
    public List<Material> skins;//liste de matériaux pour changer le skin du baord

    public AudioSource audio; //référence au son de glisse pour le mettre en pause

    public TrailRenderer snowTrail1;//référence au trail de gauche
    public TrailRenderer snowTrail2;//référence au trail de droite

    //valeurs pour storer le scroe
    int totalScore = 0;
    int currentScore;
    int highestScore = 0;


    void Update()
    {   //Va logger le score du joueur
        if(currentScore != jumpingPoints.pointsToGiveInt)
        {
            totalScore += currentScore;
        }
        currentScore = jumpingPoints.pointsToGiveInt;
        
        if(currentScore > highestScore)
        {
            highestScore = currentScore;
        }

        pointsText.text = highestScore.ToString();
        //Désactive/réactive le menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused; 
        }

        if (isPaused)
        {
            PausePlay();
        }
        else if (!isPaused)
        {
            ResumePlay();
        }
    }

    private void PausePlay()//va pauser le menu ainsi que le son et temps
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pointCounterUI.SetActive(false);
        levelUI.SetActive(false);
        audio.Pause();
    }

    public void BackToMainMenu()//Retourne au menu principal
    {
        SceneManager.LoadScene("MainMenu");//Load la scene du menu principal
    }

    public void ResumePlay()//Sensé faire l'inverse de PausePlay et unpause le jeu
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pointCounterUI.SetActive(true);
        levelUI.SetActive(true);
        audio.UnPause();
    }

    public void GoToOptions()//Active les options en activant/désactivants les éléments du UI adéquat
    {
        optionsUI.SetActive(true);
        pauseMainUI.SetActive(false);
    }

    public void BackToPause()//Désactive les options en activant/désactivants les éléments du UI adéquat
    {
        optionsUI.SetActive(false);
        pauseMainUI.SetActive(true);
    }

    public void PickSkinOne()//Si le joueur atteint le niveau 5, il pourra accéder à un "unlockable", skin de board différent avec trail de couleur
        //différente
    {
        if (levelSystem.level >= 5) 
        { 
            snowboard.material = skins[0];//change le skin du board
            //change la couleur du 1er trail
            snowTrail1.startColor = Color.red;
            snowTrail1.endColor = Color.red;
            //change la couleur du deuxième trail
            snowTrail2.startColor = Color.red;
            snowTrail2.endColor = Color.red;
        }
    }

    public void PickSkinTwo()//Si le joueur atteint le niveau 10, il pourra accéder à un "unlockable", skin de board différent avec trail de couleur
                             //différente
    {
        if (levelSystem.level >= 10)
        {
            snowboard.material = skins[1];//change le skin du board
            //change la couleur du 1er trail
            snowTrail1.startColor = Color.blue;
            snowTrail1.endColor = Color.blue;
            //change la couleur du deuxième trail
            snowTrail2.startColor = Color.blue;
            snowTrail2.endColor = Color.blue;
        }
    }

    public void PickSkinThree()//Si le joueur atteint le niveau 15, il pourra accéder à un "unlockable", skin de board différent avec trail de couleur
                               //différente
    {
        if (levelSystem.level >= 15)
        {
            snowboard.material = skins[2];//change le skin du board
            //change la couleur du 1er trail
            snowTrail1.startColor = Color.green;
            snowTrail1.endColor = Color.green;
            //change la couleur du deuxième trail
            snowTrail2.startColor = Color.green;
            snowTrail2.endColor = Color.green;
        }
    }
}
