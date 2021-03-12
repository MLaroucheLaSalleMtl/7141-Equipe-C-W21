using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingPoints : MonoBehaviour
{
    public Jump jmp;
    private float origHeight;
    public float maxHeight = 0;
    private float distance;
    public Text pointsTxt;
    public Text multiplierTxt;
    public bool started;
    private Vector3 origPos = new Vector3();
    private Vector3 endPos = new Vector3();
    private Vector3 currPos;
    float multiplier;
    float pointsToGive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator JumpSequence()
    {
        
        
       
        yield return new WaitUntil(() => jmp.grounded);
        started = false;
        endPos = transform.position;
        distance = Vector3.Distance(endPos, origPos);
        maxHeight -= origHeight;
        GivePoints();
        pointsTxt.text =  pointsToGive.ToString();
        multiplierTxt.text =  multiplier.ToString() + "X";
        
    }
    // Update is called once per frame
    void Update()
    {
       if (!jmp.grounded && !started)
        {
            maxHeight = transform.position.y;
            origHeight = maxHeight;
            started = true;
            
            origPos = transform.position;
            StartCoroutine(JumpSequence());
            
            
                
            
                
            
        }
       if (started)
        {
            currPos = transform.position;
            if (transform.position.y > maxHeight)
            {
                maxHeight = transform.position.y  ;
            }
            if (maxHeight < 1) { maxHeight = 1; }
            pointsToGive =  Vector3.Distance(currPos, origPos) ;
            multiplier = maxHeight - origHeight;
        }
       
        if (multiplier < 1) { multiplier = 1; }
        multiplierTxt.text =  multiplier.ToString("F0") + "X";
      pointsTxt.text =  pointsToGive.ToString("F0");
        
    }

    public void GivePoints()
    {
        multiplier =(int) maxHeight;
        if (multiplier == 0)
        {
            multiplier = 1;
        }
        pointsToGive = (int)distance * multiplier;
    }
    
}
