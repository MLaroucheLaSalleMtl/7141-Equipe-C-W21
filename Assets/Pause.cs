using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



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

    int currentScore;
    int highestScore = 0;
    // Update is called once per frame

    private void Start()
    {
    }

    void Update()
    {
        currentScore = jumpingPoints.pointsToGiveInt;

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
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            pointCounterUI.SetActive(false);
            levelUI.SetActive(false);

            //pauseMainUI.SetActive(true);
            //optionsUI.SetActive(false);
        }
        else if (!isPaused)
        {
            ResumePlay();
        }
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
        snowboard.material = skins[0];
    }

    public void PickSkinTwo()
    {
        snowboard.material = skins[1];
    }
}
