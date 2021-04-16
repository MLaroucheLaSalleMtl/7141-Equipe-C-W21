using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;



public class Pause : MonoBehaviour
{
    public JumpingPoints jumpingPoints;//r�f�rence au script JumpingPoints pour store des points
    public LevelSystem levelSystem;//r�f�rence au script LevelSystem pour r�cup�rer la valeur du niveau
    public Text pointsText;//r�f�rence au texte du UI pour les points
    public GameObject pauseMenu; //�l�ment du UI pour le menu pause 
    public GameObject pointCounterUI; //�l�ment du UI pour pour le point counter
    public GameObject levelUI; //�l�ment du UI pour le niveau/XP
    public GameObject optionsUI;//�l�ment du UI pour les settings dans le pause menu
    public GameObject pauseMainUI;//�l�ment du UI englobant tout ce qui est en "pause"
    public bool isPaused = false; //Bool permettant de pause/unpause le jeu

    public Renderer snowboard;//r�f au snowboard
    public List<Material> skins;//liste de mat�riaux pour changer le skin du baord

    public AudioSource audio; //r�f�rence au son de glisse pour le mettre en pause

    public TrailRenderer snowTrail1;//r�f�rence au trail de gauche
    public TrailRenderer snowTrail2;//r�f�rence au trail de droite

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
        //D�sactive/r�active le menu
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

    public void ResumePlay()//Sens� faire l'inverse de PausePlay et unpause le jeu
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pointCounterUI.SetActive(true);
        levelUI.SetActive(true);
        audio.UnPause();
    }

    public void GoToOptions()//Active les options en activant/d�sactivants les �l�ments du UI ad�quat
    {
        optionsUI.SetActive(true);
        pauseMainUI.SetActive(false);
    }

    public void BackToPause()//D�sactive les options en activant/d�sactivants les �l�ments du UI ad�quat
    {
        optionsUI.SetActive(false);
        pauseMainUI.SetActive(true);
    }

    public void PickSkinOne()//Si le joueur atteint le niveau 5, il pourra acc�der � un "unlockable", skin de board diff�rent avec trail de couleur
        //diff�rente
    {
        if (levelSystem.level >= 5) 
        { 
            snowboard.material = skins[0];//change le skin du board
            //change la couleur du 1er trail
            snowTrail1.startColor = Color.red;
            snowTrail1.endColor = Color.red;
            //change la couleur du deuxi�me trail
            snowTrail2.startColor = Color.red;
            snowTrail2.endColor = Color.red;
        }
    }

    public void PickSkinTwo()//Si le joueur atteint le niveau 10, il pourra acc�der � un "unlockable", skin de board diff�rent avec trail de couleur
                             //diff�rente
    {
        if (levelSystem.level >= 10)
        {
            snowboard.material = skins[1];//change le skin du board
            //change la couleur du 1er trail
            snowTrail1.startColor = Color.blue;
            snowTrail1.endColor = Color.blue;
            //change la couleur du deuxi�me trail
            snowTrail2.startColor = Color.blue;
            snowTrail2.endColor = Color.blue;
        }
    }

    public void PickSkinThree()//Si le joueur atteint le niveau 15, il pourra acc�der � un "unlockable", skin de board diff�rent avec trail de couleur
                               //diff�rente
    {
        if (levelSystem.level >= 15)
        {
            snowboard.material = skins[2];//change le skin du board
            //change la couleur du 1er trail
            snowTrail1.startColor = Color.green;
            snowTrail1.endColor = Color.green;
            //change la couleur du deuxi�me trail
            snowTrail2.startColor = Color.green;
            snowTrail2.endColor = Color.green;
        }
    }
}
