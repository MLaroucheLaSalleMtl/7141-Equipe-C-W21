using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrackCheckpoint : MonoBehaviour
{
    CountdownTimer timer; //Reference vers mon script CountdownTimer
    LevelSystem levelSystem; //Reference vers mon script LevelSystem
    GameManager manager; //Reference vers mon script GameManager
    public AudioSource AudioWin; //AudioSource pour jouer le son lorsque le joueur passe dans le bon checkpoint
    [SerializeField] private string nameTrack; //Pour pouvoir changer le nom de la Track directement dans unity via linterface
    public Text textGameOver;
    public int checkpointCount = 0; //Compteur pour les checkpoints
    private int lastCheckpoint; //Compteur qui sait le nombre total de checkpoint
    public bool isCompleted = false; //Bool 

    private List<Checkpoint> checkpointList; //La liste de checkpoint
    private int nextCheckpointIndex; //Pour detecter si le prochain Checkpoint est vraiment le next
   
    private void Awake()
    {
        Transform checkpointsTransform = transform.Find(nameTrack); //Prend le nom pour l'object parent
        
        checkpointList = new List<Checkpoint>(); //Initialise ma liste
        
        foreach(Transform checkpointTransform in checkpointsTransform) //Pour chaque checkpoint
        {
            Checkpoint checkpoint = checkpointTransform.GetComponent<Checkpoint>(); //Pour avoir acces au script checkpoint

            checkpoint.SetTrackCheckpoints(this); //Faire reference au Checkpoint
            
            checkpointList.Add(checkpoint); //Ajoute le checkpoint a la liste
        }
        lastCheckpoint = checkpointList.Count; //Calcul le nombre total de checkpoint
        nextCheckpointIndex = 0; //Pour bouger dans ma liste de checkpoint
        checkpointCount = 1; //Compteur initialiser a 1
    }

    IEnumerator WaitAndReload() //Fonction qu va attendre et reload la scene
    {
        yield return new WaitForSeconds(3.0f); //Attend 3 sec
        Scene scene = SceneManager.GetActiveScene(); //Prend la scene active
        SceneManager.LoadScene(scene.name); //Reload la scene
    }

    public void PlayerThroughCheckpoint(Checkpoint checkpoint) //Fonction quand le joueur passe dans le checkpoint
    {
        if (checkpointList.IndexOf(checkpoint) == nextCheckpointIndex) //Verifie si le checkpoint et dans la liste
        {
            AudioWin.Play(); //Joue l'audio
            nextCheckpointIndex = (nextCheckpointIndex + 1) % checkpointList.Count; //Incremente l'index
            if (lastCheckpoint == checkpointCount) //Si tu arrive au derrnier checkpoint
            {
                isCompleted = true; //Rend la variable isCompleted a true
            };
            //timer.totalTime += 10.0f;
            
        }
        else //Si le checkpoint n'est pas le prochain dans la liste
        {
            textGameOver.gameObject.SetActive(true); //Rend le texte gameover visible 
            StartCoroutine("WaitAndReload"); //Start WaitAndReload
        }
    }
}
