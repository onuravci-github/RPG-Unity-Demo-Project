using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Düşmanın sahip olduğu özellikleri belirleyen script
public class EnemyFeatures : MonoBehaviour
{
    public float healt = 100;

    public Transform healtBarParent;
    public Transform healtBar;
    private float healtBarMax;

    private ParticleSystem[] partics;
    private Rigidbody robotRigidBody;

    public float speedUp = 1f;
    public float speedRobot = 0.1f;
    public float rotateSpeed = 5f;

    public bool enemyMissShot = false;
    public bool isFightStart = false;
    public bool isFirstLocation = true;
    public bool isSee = false; // Dont see
    public bool isFollow = false; // Can't Follow
    public bool isEscape = true; // Character Escaped
    public bool isShotStart = false;
    public bool isDie = false;

    private Vector3 firstLocation;
    private Vector3 distance;

    public RobotShot[] shotObjects;
    
    public static GameObject CharacterObject;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        firstLocation = this.transform.position;
        healtBarMax = healt;
        partics = this.GetComponentsInChildren<ParticleSystem>();
        robotRigidBody = this.GetComponent<Rigidbody>();
        CharacterObject = GameObject.FindGameObjectWithTag("Character");

        Invoke("RotateChangeStart",0.02f);
    }
    // Update is called once per frame
    void Update()
    {   if(!isDie){
            if((isEscape && isFirstLocation) || (!isEscape && isFirstLocation && !isFightStart)){
                isShotStart = false;
                robotRigidBody.velocity = new Vector3(Mathf.Sin(transform.eulerAngles.y*Mathf.PI/180)*speedUp*speedRobot,0,Mathf.Cos(transform.eulerAngles.y*Mathf.PI/180)*speedUp*speedRobot);
            }
            else if((isSee && !isEscape && isFightStart) && !isFollow){
                distance = (CharacterObject.transform.position - transform.position).normalized;
                robotRigidBody.velocity = distance*speedUp*speedRobot;
                this.transform.rotation=Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(distance),rotateSpeed*Time.deltaTime);
                if(!isShotStart){
                    isShotStart = true;  
                    foreach (var item in shotObjects) { item.ShotStart();} 
                }
            }
            else if((!isEscape && isFightStart && isFollow && isSee) ){
                distance = (CharacterObject.transform.position - transform.position).normalized;
                robotRigidBody.velocity = Vector3.zero;
                this.transform.rotation=Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(distance),rotateSpeed*Time.deltaTime);
                if(!isShotStart){
                    isShotStart = true;  
                    foreach (var item in shotObjects) { item.ShotStart();} 
                }
            }
            else if((!isEscape && isFirstLocation && isFightStart) || (!isEscape && isFollow && isFirstLocation && isFightStart) ){
                isShotStart = false;
                foreach (var item in shotObjects) { item.CancelShot(); }
                distance = (CharacterObject.transform.position - transform.position).normalized;
                robotRigidBody.velocity = distance*speedUp*speedRobot;

                this.transform.rotation=Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(distance),rotateSpeed*Time.deltaTime);
            }
        }
        
        
    }

    //Rotate Walk robots
    public void RotateChangeStart(){
        Invoke("CancelRotate",1f);
        
        InvokeRepeating("SmoothRotate",0.033f,0.033f);
        Invoke("RotateChangeStart",3f);
    }
    public void CancelRotate(){
        CancelInvoke("SmoothRotate");
    }
    public void CancelRotateChangeStart(){
        CancelInvoke("RotateChangeStart");
    }
    public void SmoothRotate(){
        if(isFightStart){}
        else this.transform.eulerAngles = new Vector3(0,transform.eulerAngles.y-5,0);
    }

    public void GoToFirstLocation(){
        CancelInvoke("RotateChangeStart");
        CancelRotate();

        speedUp = 2;
        foreach (var item in shotObjects) { item.AmmoReset(); item.CancelShot(); } 
        InvokeRepeating("GoFirstVelocity",0.02f,0.02f);
        
    }
    void GoFirstVelocity(){
        distance = firstLocation - transform.position;
        distance = distance.normalized ;
        //distance = new Vector3(distance.x,0,distance.z);
        robotRigidBody.velocity = distance;
        if(Vector3.Distance(transform.position,firstLocation) <= 0.1f){
            isFirstLocation = true;
            speedUp = 1;
            CancelInvoke("GoFirstVelocity");
            Invoke("RotateChangeStart",0.02f);
        }
    }


    void EnemyMissShot(){

    }


    


    //Robot Less Damage
    public void TakeDamage(int gunPower){
        if(!isDie){
            healt -= gunPower;
            if(isEscape){
                healt+= healtBarMax*0.3f;
                if(healt >=healtBarMax){healt = healtBarMax;}
            }
            if(!isEscape){
                isFightStart = true;
            }

            if(healt <= 0){
                isDie = true;
                Die();
                healtBar.localScale = Vector3.zero;
                healtBarParent.localScale = Vector3.zero;
            }

            healtBar.localScale = new Vector3(healt/healtBarMax,healtBar.localScale.y,healtBar.localScale.z);
        }
        
    }
    //Robot die Animation Player
    private void Die(){
        for (int i = 0; i < partics.Length; i++)
        {
            partics[i].Play();
        }
        this.GetComponent<Animator>().SetBool("Dead",true);
        
        isShotStart = false;
        foreach (var item in shotObjects) { item.CancelShot(); }
        
    }

    //Robot Destroy Anim end
    public void DestroyObject(){
        Destroy(this.gameObject);
    }
}
