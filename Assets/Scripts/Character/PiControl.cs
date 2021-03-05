using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiControl : MonoBehaviour
{
    public static GameObject piObject;
    public static Animator piAnimator;
    public static Transform thisTransform;

    private GameObject resourceObject;
    private static GameObject playerCanvasObject;
    private static GameObject selectBox;

    public GameObject[] PiMessage;

    public GameObject[] Deneme;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ReadyPI",2f);
        
    }
    public void ReadyPI(){
        thisTransform = this.transform;
        playerCanvasObject = GameObject.FindGameObjectWithTag("Player Canvas");
        selectBox = GameObject.FindGameObjectWithTag("Character Select Box");
        piObject = Instantiate(Resources.Load<GameObject>("Prefabs/Pi/Pi"),new Vector3((thisTransform.position.x+0.25f),(thisTransform.position.y+0.35f),(thisTransform.position.z-0.15f)),Quaternion.identity)as GameObject;
        piObject.transform.parent = thisTransform;
        piAnimator = piObject.GetComponent<Animator>();
        piAnimator.SetBool("Pi Start",true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H ) && piObject == null){
            PiCreate();
        }
        if(Input.GetKeyDown(KeyCode.J ) && piObject != null){
            PiDestroy();
        }
        if(Input.GetKeyDown(KeyCode.F1 ) && piObject != null){
            OpenMessage1();
        }
        if(Input.GetKeyDown(KeyCode.F2 ) && piObject == null){
            OpenMessage2();
        }
        //piObject.transform.position = new Vector3(thisTransform.position.x+(0.25f*Mathf.Cos(thisTransform.eulerAngles.y*Mathf.PI/180)),thisTransform.position.y+0.35f,thisTransform.position.z-0.15f);
        //piObject.transform.rotation = Quaternion.Slerp(piObject.transform.rotation,Quaternion.LookRotation((transform.position - piObject.transform.position).normalized),50*Time.deltaTime);
    }

    public static void PiCreate(){
        piObject = Instantiate(Resources.Load("Prefabs/Pi/Pi",typeof(GameObject)),new Vector3(thisTransform.position.x+0.25f,thisTransform.position.y+0.35f,thisTransform.position.z-0.15f),Quaternion.identity)as GameObject;
        piObject.transform.parent = thisTransform;
        piAnimator = piObject.GetComponent<Animator>();
        piAnimator.SetBool("Pi Start",true);
    }
    public static void PiCombineCreate(){
        if(piObject){
            PiDestroy();
        }
        CharacterMovement.CharacterControl = false;
        playerCanvasObject.SetActive(false);
        selectBox.SetActive(false);
        piObject = Instantiate(Resources.Load("Prefabs/Pi/Pi",typeof(GameObject)),new Vector3(thisTransform.position.x+0.25f,thisTransform.position.y+0.35f,thisTransform.position.z-0.15f),Quaternion.identity)as GameObject;
        piAnimator = piObject.GetComponent<Animator>();
        piAnimator.SetBool("Pi Start",false);
        piAnimator.SetBool("Craft Combine Start",true);
    }

    public static void PiCombineFinish(){
        playerCanvasObject.SetActive(true);
        selectBox.SetActive(true);
        PiDestroy();
    }

    public static void PiDestroy(){
        Destroy(piObject.gameObject);
        piObject = null;
    }


    public void OpenMessage1(){
        PiMessage[0].SetActive(true);
        Invoke("MessageOff",5f);

    }
    public void MessageOff(){
        foreach (var item in PiMessage)
        {
            item.SetActive(false);
        }
    }
    public void OpenMessage2(){

        foreach (var item in Deneme)
        {
            item.SetActive(true);
        }

        PiMessage[1].SetActive(true);
        Invoke("MessageOff",5f);
    }
}
