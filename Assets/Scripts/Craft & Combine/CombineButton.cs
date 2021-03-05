using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombineButton : MonoBehaviour
{
    public GameObject[] messageObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Succesfull(){
        if(Combine.complateNumb == Combine.iscomplate){
            messageObject[0].SetActive(true);
            Invoke("Finish",1f);
        }
        else{
            messageObject[1].SetActive(true);
            Invoke("RestartPlease",1f);
        }
        
    }

    void Finish(){
        PiControl.PiCombineFinish();
        //GameObject.FindGameObjectWithTag("Pi").GetComponent<Animator>().SetBool("Craft Combine Finish",true);
        
    }

    void RestartPlease(){
        messageObject[1].SetActive(false);
    }
}
