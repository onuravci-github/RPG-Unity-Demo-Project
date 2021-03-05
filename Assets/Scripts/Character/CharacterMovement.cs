using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Karakterin Hızını Ayarlayan 
public class CharacterMovement : MonoBehaviour
{
    public GameObject CursorObject;
    private Rigidbody CharacterRigidBody;
    private Vector3 mouseVector;

    public int rotationSpeedX = 180;
    public int rotationSpeedY = 90;
    public float SpeedCharacter = 0.5f;
    public float ShiftSpeedUp = 1;
    public int gravity;

    private bool Jump = true;
    public float jumpForce = 1f;

    private bool W;
    private bool A;
    private bool S;
    private bool D;

    public static bool CharacterControl = true;

    private void Awake() {
        Application.targetFrameRate = 60;
    }


    // Start is called before the first frame update
    void Start()
    {
        CharacterRigidBody = this.GetComponent<Rigidbody>();
    }
    

    private void Update() {
        if(CharacterControl){   
            CursorObject.SetActive(true);

            // Character Velocity Zero
            CharacterRigidBody.velocity = new Vector3(0,0,0);
            ShiftSpeedUp = 1;


            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            // Speed Up x1.5
            if(Input.GetKey(KeyCode.LeftShift)){
                ShiftSpeedUp = 1.5f;
            }
            if(Input.GetKeyDown(KeyCode.Space)){
                CharacterRigidBody.AddExplosionForce(1,new Vector3(0,6,0),1,1,ForceMode.Force);
            }
            if(Input.GetKeyDown(KeyCode.LeftControl)){
                transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y-0.5f,transform.localPosition.z);
            }
            if(Input.GetKeyUp(KeyCode.LeftControl)){
                transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y+0.5f,transform.localPosition.z);
            }
            if(Input.GetKeyDown(KeyCode.W)){
                //this.GetComponentInChildren<Animator>().SetBool("Move W",true);
            }
            if(Input.GetKeyUp(KeyCode.W)){
                //this.GetComponentInChildren<Animator>().SetBool("Move W",false);
            }

            if(Input.GetKeyDown(KeyCode.Space) && Jump){
     
                 CharacterRigidBody.AddRelativeForce(new Vector3(0,jumpForce,0) , ForceMode.Impulse);
                 Jump = true;
            }
            // Velocity Object Set
            if(Input.GetKey(KeyCode.W)){ W = true;
                CharacterRigidBody.velocity = new Vector3(Mathf.Sin(transform.eulerAngles.y*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter,0,Mathf.Cos(transform.eulerAngles.y*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter);
            }
            if(Input.GetKey(KeyCode.A)){ A = true;
                CharacterRigidBody.velocity = new Vector3(-Mathf.Sin((90+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.9f,0,-Mathf.Cos((90+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.9f);
            }
            if(Input.GetKey(KeyCode.S)){ S = true;
                CharacterRigidBody.velocity = new Vector3(Mathf.Sin(transform.eulerAngles.y*Mathf.PI/180)*ShiftSpeedUp*-SpeedCharacter*0.7f,0,Mathf.Cos(transform.eulerAngles.y*Mathf.PI/180)*ShiftSpeedUp*-SpeedCharacter*0.7f);
            }
            if(Input.GetKey(KeyCode.D)){ D = true;
                CharacterRigidBody.velocity = new Vector3(Mathf.Sin((90+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.8f,0,Mathf.Cos((90+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.8f);
            }
            if(W && A){
                CharacterRigidBody.velocity = new Vector3(Mathf.Sin((-45+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.9f,0,Mathf.Cos((-45+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.9f);
            }
            if(W && D){
                CharacterRigidBody.velocity = new Vector3(Mathf.Sin((45+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.9f,0,Mathf.Cos((45+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.9f);
            }
            if(S && D){
                CharacterRigidBody.velocity = new Vector3(-Mathf.Sin((-45+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.7f,0,-Mathf.Cos((-45+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.7f);
            }
            if(S && A){
                CharacterRigidBody.velocity = new Vector3(-Mathf.Sin((45+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.7f,0,-Mathf.Cos((45+transform.eulerAngles.y)*Mathf.PI/180)*ShiftSpeedUp*SpeedCharacter*0.7f);
            }
            ////////////////////////////////
            
            
            // Update Set Zero
            W = false; A = false; S= false; D = false;
            ////////////////////////////////
        }
        else CursorObject.SetActive(false);
        
    }
    private void OnCollisionStay(Collision other) {
        
    }
}