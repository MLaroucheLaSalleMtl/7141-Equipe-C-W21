using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBall : MonoBehaviour
{
    //Script par Frédéric Lessard sauf parties marqués autrement 
    private Rigidbody rb; //Rigidbody de la balle
    public GameObject targetSphere; //Sphere target
    public GameObject motherSphere; // Sphere mère de target
    private MoveTarget2 mt; //Script Move target sur targetsphere
    public Jump jmp; //Script jump
    public JumpList jl; // script jump list
    public RagdollControll rag; //Scriopt ragdollcontroll

    public bool isSpeedingUp = false; //Bool pour le input system
    private bool isSlowingDown = false;//Bool pour le input system
    private bool isTurningRight = false;//Bool pour le input system
    private bool isTurningLeft = false;//Bool pour le input system

    public float speed; //vitesse visée du joueur
    public float maxSpeed;//vitesse maximale du joueur
    public float currentSpeed; //Vitesse actuelle du joeur

    //Guillaume Desgagné
    private float speedVolume = 0; 
    public AudioSource snowSound;
    public AudioSource railSound;

    //Frederic vv
    public Vector3 direction = new Vector3();//Direction du joueur pour la vitesse
    private Vector3 dir = new Vector3(); //Direction du joueur pour le controle perpendiculaire
    private Vector3 dirLeft = new Vector3(); //Direction perpendiculaire vers la gauche
    private Vector3 dirRight = new Vector3(); //Direction perpendiculaire ver la droite

    //Ajoute de la force inverse quand le snowboard est perpendiculaire à la direction dont il glisse
    private void PerpendStopping() {
        float perpSpeed = speed / 3; //vitesse perpendiculaire

        //Trouvé ce calcul sur internet
        //https://answers.unity.com/questions/697830/how-to-calculate-direction-between-2-objects.html
        dir = (transform.position - targetSphere.transform.position).normalized; 

        
        dirRight = Vector3.Cross(dir, Vector3.up).normalized;//Perpendiculaire à la direction
        dirLeft = -dirRight; //Perpendiculaire gauche
        if (isTurningLeft)
        {
            rb.AddForce(dirLeft * perpSpeed, ForceMode.Force); //ajoute de la force
        }
        else if (isTurningRight)
        {
            rb.AddForce(dirRight * perpSpeed, ForceMode.Force); //ajoute de la force
        }
        SlippageCorrection();
    }   

    //Rectifie le glissage non-désiré
    private void SlippageCorrection()
    {
        int frame = 1; //Calcul le nombre de frames
        Vector3 firstPos = new Vector3(); //Premiere position pour le calcul de la direction du glissage
        Vector3 secPos = new Vector3();   //Deuxieme ¨¨
        Vector3 slipDir = new Vector3(); //Direction du glissage
        
        //Prends les positions
        if (frame == 1)
        {
            firstPos = transform.position;
            frame++;
        }else if (frame == 2)
        {
            secPos = transform.position;
            frame--;
        }

        slipDir = (firstPos - secPos).normalized;//Meme calcul que plus haut ^^
       
        //Ajoute de la force pour rectifier le glissage
        if (jmp.grounded)
        {
            rb.AddForce(-slipDir * currentSpeed/2, ForceMode.Force);
        }else if (jl.approchingJump || !jmp.grounded)
        {
            rb.AddForce(-slipDir * currentSpeed/5, ForceMode.Force);
        }

    }
  
    // Input system pour avancer
public void OnForward(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSpeedingUp = true;

        } else if (context.canceled)
        {
            isSpeedingUp = false;
        }
    }
    //Ralentir
    public void OnSlowDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSlowingDown = true;
        } else if (context.canceled)
        {
            isSlowingDown = false;
        }
    }

    //pencher à droite
    public void OnTurnRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isTurningRight = true;
        }
        else if (context.canceled)
        {
            isTurningRight = false;
        }
    }
    //pencher à gauche
    public void OnTurnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isTurningLeft = true;
        }
        else if (context.canceled)
        {
            isTurningLeft = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mt = targetSphere.GetComponent<MoveTarget2>();
    }

    // Update is called once per frame
    void Update()
    {
        
        PerpendStopping();

        direction = (targetSphere.transform.position - transform.position).normalized;//Trouve la direction
        Vector3 leftDir = Vector3.Cross(direction, Vector3.up).normalized; //Direction droite
        Vector3 rightDir = Vector3.Cross(direction, Vector3.down).normalized; //Direction gauche
        
        //Guillaume vv
        speedVolume = (currentSpeed / maxSpeed); //Pour calculer le volume des AudioSource
        if(rag.isDead == true)//Si le player se retrouve en Ragdoll
        {
            snowSound.Stop(); //Arrete le son du snowboard
        }
        if (jmp.onRail == true)//Si le player fait une rail
        {
            railSound.volume = speedVolume; //Augmente le son selon la vitesse
        }
        else //Si le player ne fait pas de rail
        {
            railSound.volume = 0; //volume = 0
        }
        if (jmp.grounded == true) //Si le payer touche le sol
        {
            snowSound.volume = speedVolume; //Augmente le son selon la vitesse
        }
        else //Si le player n'est pas grounded
        {
            snowSound.volume = 0; //volume = 0;
        }
        

        //Frederic vv
        currentSpeed = rb.velocity.magnitude; //Vitesse actuelle
        //Input system pour controller le personnage
        if (isSpeedingUp && !mt.upSlope)
        {
            rb.AddForce(direction * speed*2, ForceMode.Acceleration);

        } if (isSlowingDown && rb.velocity.magnitude > 0 && !mt.upSlope)
        {
            rb.AddForce(direction * -speed*2, ForceMode.Acceleration);

        } if (isTurningRight)
        {
            rb.AddForce(rightDir * speed, ForceMode.Acceleration); 
          
        } if (isTurningLeft)
        {
            rb.AddForce(leftDir * speed, ForceMode.Acceleration);
         
        } 
    }
    private void FixedUpdate()
    {
        //Controle la vistesse maximale
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    



        



    
        
}
