using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Jump jump;

    public MoveTarget2 mt2;

    public GameObject snowboard;

    public TrailRenderer snowTrail;


    public float trailWidth
    {
        get { return _trailWidth; }
        set { _trailWidth = Mathf.Clamp(value, 1f, 5f); }
    }

    public float _trailWidth { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        snowTrail = GetComponent<TrailRenderer>();

        // Set some positions
        /*Vector3[] positions = new Vector3[3];
        positions[0] = new Vector3(-2.0f, -2.0f, 0.0f);
        positions[1] = new Vector3(0.0f, 2.0f, 0.0f);
        positions[2] = new Vector3(2.0f, -2.0f, 0.0f);
        snowTrail.SetPositions(positions);*/

        Debug.Log(snowTrail.transform.parent);
        //snowTrail.alignment = LineAlignment.TransformZ;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mt2.angle);
        trailWidth = Mathf.Abs(mt2.angle) * .15f;
        //snowTrail.widthMultiplier = trailWidth;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit,0.25f))
        {
            //snowTrail.enabled = true;
            //snowTrail.transform.parent = snowboard.transform;
            snowTrail.emitting = true;
        }
        else
        {
            //snowTrail.enabled = false;
            //snowTrail.transform.parent = null;
            snowTrail.emitting = false;
        }
    }
}
