using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private string currentScene; //Pour le nom de la scene courrante
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name; //Prend le nom de la scene
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")) //Si tu appuie sur R
        {
            SceneManager.LoadScene(currentScene); //Reload la scene
        }
    }
}
