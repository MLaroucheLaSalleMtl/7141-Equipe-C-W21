using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public Text timerText; //Pour referencer mon texte timer dans l'engine
    public Text GameOver; //Pour referencer mon texte gameover dans l'engine
    [SerializeField] public float totalTime; //Pour pouvoir changer le temps manuellement dans l'engine
    private bool isCountingDown = false; //Bool pour quand le timer atteindra 0
   
    IEnumerator WaitAndReload() //Fonction qu va attendre et reload la scene
    {   
        yield return new WaitForSeconds(3.0f); //Attend 3 sec
        Scene scene = SceneManager.GetActiveScene(); //Prend la scene active
        SceneManager.LoadScene(scene.name); //Reload la scene
    }


    void Update()
    {
        if (isCountingDown != true) //Si le Timer n'a pas encore atteint 0
        {
            totalTime -= Time.deltaTime; //Descend le timer
            timerText.text = totalTime.ToString("f1"); //Met a jour le texte
        }
        if (totalTime <= 0.0f) //Si le temps arrive a 0 arrete le Timer
        {
            isCountingDown = true; //Met le bool a true
            timerEnded(); //Entre dans la fonction timerEnded()
        }
        
    }
    void timerEnded()
    {
        GameOver.gameObject.SetActive(true); //Fait apparaitre le texte GameOver
        StartCoroutine("WaitAndReload"); //Start la coroutine
    }
}
