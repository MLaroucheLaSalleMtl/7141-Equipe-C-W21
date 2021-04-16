using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()//Load la scène principale
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()//Quitte le jeu
    {
        Application.Quit();
    }

}
