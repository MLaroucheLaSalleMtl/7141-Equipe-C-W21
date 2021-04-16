using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; //L'instance de mon GameManager
    //public bool isCompleted = false;
    [SerializeField] private int amountPerCheckpoint = 30; //Montant d'exp par checkpoint
    private int totalXP; //L'experience total que le joueur va recevoir
    public Text winText;
    private LevelSystem levelSystem; //Reference au script LevelSystem
    private CountdownTimer time; //Reference au script CountdownTimer
    public TrackCheckpoint trackCheckpoint; //Reference au script TrackCheckpoint

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this) //Singleton pour ne pas avoir 2 GameManager
        {
            Destroy(gameObject);
        }
        levelSystem = new LevelSystem();

    }
    private void Start()
    {
        trackCheckpoint = trackCheckpoint.GetComponent<TrackCheckpoint>();
    }
    IEnumerator WaitAndLoad() //Fonction qu va attendre et reload la scene
    {
        yield return new WaitForSeconds(3.0f); //Attend 3 sec
        SceneManager.LoadScene(0); //Reload la scene
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(trackCheckpoint.isCompleted);
        if (trackCheckpoint.isCompleted == true) //Si la track est complete
        {
            winText.gameObject.SetActive(true);
            totalXP = (trackCheckpoint.checkpointCount - 1) * amountPerCheckpoint; //Calcul de l'xp
            levelSystem.AddExperience(totalXP); //Ajout de l'xp
            trackCheckpoint.isCompleted = false; //Remet ma variable isCompleted a false
            StartCoroutine("WaitAndLoad");
        }
    }
}
