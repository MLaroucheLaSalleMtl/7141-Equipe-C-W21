using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;



public class Pause : MonoBehaviour
{
    public JumpingPoints jumpingPoints;
    public Text pointsText;
    public GameObject pauseMenu;
    public GameObject pointCounterUI;
    public GameObject levelUI;
    public GameObject optionsUI;
    public GameObject pauseMainUI;
    public bool isPaused = false;

    public Renderer snowboard;
    public List<Material> skins;

    public AudioSource audio;
    public AudioMixer audioMixer;

    int totalScore = 0;
    int currentScore;
    int highestScore = 0;
    // Update is called once per frame

    private void Start()
    {
    }

    void Update()
    {
        if(currentScore != jumpingPoints.pointsToGiveInt)
        {
            totalScore += currentScore;
        }
        currentScore = jumpingPoints.pointsToGiveInt;
        
        //Debug.Log("total score:"+totalScore);
        if(currentScore > highestScore)
        {
            highestScore = currentScore;
        }

        pointsText.text = highestScore.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            PausePlay();

            //pauseMainUI.SetActive(true);
            //optionsUI.SetActive(false);
        }
        else if (!isPaused)
        {
            ResumePlay();
        }
    }

    private void PausePlay()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pointCounterUI.SetActive(false);
        levelUI.SetActive(false);
        audio.Pause();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumePlay()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pointCounterUI.SetActive(true);
        levelUI.SetActive(true);
        audio.UnPause();

        //pauseMainUI.SetActive(true);
        //optionsUI.SetActive(false);
    }

    public void GoToOptions()
    {
        optionsUI.SetActive(true);
        pauseMainUI.SetActive(false);
    }

    public void BackToPause()
    {
        optionsUI.SetActive(false);
        pauseMainUI.SetActive(true);
    }

    public void PickSkinOne()
    {
        if (totalScore >= 30) 
        { 
            snowboard.material = skins[0];
        }
    }

    public void PickSkinTwo()
    {
        snowboard.material = skins[1];
    }
}
