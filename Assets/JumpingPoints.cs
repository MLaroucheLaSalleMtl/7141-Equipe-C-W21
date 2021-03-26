using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingPoints : MonoBehaviour
{
    public Jump jmp;
    public LevelSystem level;

    public float maxHeight = 0;
    private float distance;
    public Text pointsTxt;
    public Text multiplierTxt;
    public bool started;
    private Vector3 origPos = new Vector3();
    private Vector3 endPos = new Vector3();
   
    float multiplier;
    float pointsToGive;
    public int pointsToGiveInt;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator JumpSequence()
    {
        
        
       
        yield return new WaitUntil(() => jmp.grounded);
        started = false;
        endPos = transform.position;
        distance = Vector3.Distance(origPos, transform.position);
        
        GivePoints();
        anim.SetTrigger("Landed");
        pointsTxt.text =  pointsToGive.ToString();
        multiplierTxt.text =  multiplier.ToString() + "X";
        
    }
    // Update is called once per frame
    void Update()
    {
       if (!jmp.grounded && !started)
        {
            maxHeight = 0f;
            
            started = true;
            
            origPos = transform.position;
            StartCoroutine(JumpSequence());
            
            
                
            
                
            
        }
       if (started)
        {
           

            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
               if (hit.distance > maxHeight)
                {
                    maxHeight = hit.distance;
                    if (maxHeight < 1) { maxHeight = 1; }
                    multiplier = maxHeight / 2;
                }
                
            }
            pointsTxt.text = Vector3.Distance(origPos, transform.position).ToString("F0");

        }

        if (multiplier < 1) { multiplier = 1; }
        multiplierTxt.text =  multiplier.ToString("F0") + "X";
        // pointsTxt.text = Vector3.Distance(origPos, transform.position).ToString("F0");
    }

    public void GivePoints()
    {
        multiplier =(int) maxHeight / 2;
        if (multiplier == 0)
        {
            multiplier = 1;
        }
        pointsToGive = (int)distance * multiplier;
        pointsToGiveInt = (int)Mathf.Round(pointsToGive);
        level.AddExperience(pointsToGiveInt);
        Debug.Log("Point" + pointsToGiveInt);
    }
    
}
