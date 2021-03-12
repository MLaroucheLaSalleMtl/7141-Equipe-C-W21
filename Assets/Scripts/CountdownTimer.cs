using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text timerText;
    private string preText = "Time: ";
    [SerializeField] public float totalTime;
    private bool isCountingDown = false;
   
    void Start()
    {
      
    }


    void Update()
    {
        if (isCountingDown != true)
        {
            totalTime -= Time.deltaTime;
            timerText.text = preText + totalTime.ToString("f1");
        }
        if (totalTime <= 0.0f)
        {
            isCountingDown = true;
            timerEnded();
        }
        
    }
    void timerEnded()
    {

    }
}
