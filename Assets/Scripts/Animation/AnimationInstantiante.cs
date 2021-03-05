using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Haritada bulunn yerden alınan esneler ve sandıklar için animasyonlarını oluşturmak için script
public class AnimationInstantiante : MonoBehaviour
{
    public GameObject animationObject;
    private GameObject CharacterObject;
    private GameObject InstantianteObject;

    private Quaternion quaternion = new Quaternion(0,0,0,0);

    private bool isStart = true;

    private float positionDistanceX;
    private float positionDistanceY;
    private float positionDistanceZ;
    private float distanceControl = 0.35f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CharacterObject != null ){
            positionDistanceX = CharacterObject.transform.position.x - this.transform.position.x;
            positionDistanceY = CharacterObject.transform.position.y - this.transform.position.y;
            positionDistanceZ = CharacterObject.transform.position.z - this.transform.position.z;
            
            if(positionDistanceX < -distanceControl || positionDistanceX > distanceControl || positionDistanceY < -distanceControl || positionDistanceY > distanceControl || positionDistanceZ < -distanceControl || positionDistanceZ > distanceControl){
                Destroy(InstantianteObject);
                CharacterObject = null;
                isStart = true;
            }
        }

        if(InstantianteObject != null && Input.GetKeyDown(KeyCode.F)){
            // Money ++
            if(this.gameObject.tag != "Chest")MainMoneyText.MainMoneyADD(1);
            Destroy(InstantianteObject);
            if(this.gameObject.tag != "Chest"){Destroy(this.gameObject);}
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Character Select Box" && isStart){
            isStart = false;
            CharacterObject = other.gameObject;
            if(this.gameObject.tag == "Chest")
                InstantianteObject = Instantiate(animationObject,new Vector3(this.transform.localPosition.x,this.transform.localPosition.y+0.15f,this.transform.localPosition.z+0.085f),quaternion);
            else
                InstantianteObject = Instantiate(animationObject,new Vector3(this.transform.localPosition.x,this.transform.localPosition.y+0.02f,this.transform.localPosition.z+0.05f),quaternion); 
        }
    }

    /*private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "CharacterSelectBox" && isStart){
            isStart = false;
            CharacterObject = other.gameObject;
            if(this.gameObject.tag == "Chest")
                InstantianteObject = Instantiate(animationObject,new Vector3(this.transform.localPosition.x,this.transform.localPosition.y+0.085f,this.transform.localPosition.z+0.085f),quaternion);
            else
                InstantianteObject = Instantiate(animationObject,new Vector3(this.transform.localPosition.x,this.transform.localPosition.y+0.02f,this.transform.localPosition.z+0.05f),quaternion); 
        }
    }*/


}
