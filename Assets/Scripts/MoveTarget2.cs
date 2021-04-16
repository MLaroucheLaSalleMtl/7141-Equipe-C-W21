using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Allo
public class MoveTarget2 : MonoBehaviour
{
    public GameObject board; //Snowboard
    public GameObject motherSphere; //Sphere mère
    public MoveBall moveBall; //Script moveball
    public GameObject ball; //Sphere du personnage
    private Jump jmp; //Script Jump
    public JumpList jmpList; //Script jumplist

    public float angle; //Angle de la sphere comparé à sa sphere mère
    

    private bool turningRight = false; //Tourner à droite
    private bool turningLeft = false; // ¨¨     ¨¨ gauche

   
    public bool upSlope = false; //bool pour savoir si la pente monte ou descends

    RaycastHit hitInfo; //Raycast pour trouver le sol
    private Vector3 pos = new Vector3(); //position de la sphere

    /// <summary>
    /// Référence pour Ground();
    /// Jason Weimann, Snap your GameObjects to the ground with a simple hotkey,Youtube, 26 sept 2017 de https://www.youtube.com/watch?v=gLtjPxQxJPk&t=33s&ab_channel=JasonWeimann
    /// </summary>
    private void Ground()
    {

        if (Physics.Raycast(transform.position + Vector3.up + Vector3.up, Vector3.down, out hitInfo, 100)) //trouve le sol
        {
            pos.y = hitInfo.point.y;
        }
    }

    //Input system pour tourner à gauche
    public void OnTurnLeft(InputAction.CallbackContext context)
    {

        if ( context.performed)
        {
            turningLeft = true;
        }else if (context.canceled)
        {
            turningLeft = false;
        }
    }

    //Input system pour tourner à droite
    public void OnTurnRight(InputAction.CallbackContext context)
    {
        
            if (context.performed)
            {
            turningRight = true;
            }else if (context.canceled)
        {
            turningRight = false;
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        moveBall = ball.GetComponent<MoveBall>();
        jmp = GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (turningRight && jmp.grounded )
        {
            //Fait rotationner la sphere autour du joueur
            transform.RotateAround(board.transform.position, Vector3.up, 120 * Time.deltaTime);
            angle++;
            
        }else if (turningRight && !jmp.grounded){
            //Fait rotationner la sphere autour du joueur plus vite quand le joueur saute
            transform.RotateAround(board.transform.position, Vector3.up, 300 * Time.deltaTime);
        }
        if (turningLeft  && jmp.grounded)
        {
            //Fait rotationner la sphere autour du joueur
            transform.RotateAround(board.transform.position, Vector3.down, 120 * Time.deltaTime);
            angle--;

        }else if (turningLeft && !jmp.grounded){
            //Fait rotationner la sphere autour du joueur plus vite quand le joueur saute
            transform.RotateAround(board.transform.position, Vector3.down, 300 * Time.deltaTime);
        }
       
        Ground(); //Check le ground
        transform.position = new Vector3(transform.position.x, pos.y, transform.position.z); //ramène la balle au niveau du sol (utile pour que le snowboard sois toujours dans le meme angle que la pente)

        //Trouve la distance entre le joueur et la balle
        if (Vector3.Distance(transform.position, board.transform.position) < 10)
        {
            //Ramène la balle à 10 mètres devant le joueur en tout temps (peu impote la direction) 
            transform.position += new Vector3(moveBall.direction.x, moveBall.direction.y, moveBall.direction.z) ;
        }
        
        //Regarde si la pente devant le joueur monte ou descend pour ne pas pouvoir monter une pente
        if ((transform.position.y > board.transform.position.y + 3 || transform.position.y > board.transform.position.y +5) && !jmpList.approchingJump)
        {
            upSlope = true;
        }
        else
        {
            upSlope = false;
        }
    }
}
