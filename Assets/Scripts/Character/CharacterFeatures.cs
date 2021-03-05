using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterFeatures : MonoBehaviour
{
    public int healt = 100;
    public float maxHealt;
    public Text healtText;
    public RectTransform healtRect;
    
    // Start is called before the first frame update
    void Start()
    {
        maxHealt = healt;
    }

    // Update is called once per frame
    void Update()
    {
        healtText.text = healt.ToString();
        healtRect.localScale = new Vector3(healt/maxHealt,1,1);
        
    }



    public void TakeDamage(int gunPower){
        healt -= gunPower;
        
        if(healt <= 0){
            Die();
            //healtBar.localScale = Vector3.zero;
            //healtBarParent.localScale = Vector3.zero;
        }

        //healtBar.localScale = new Vector3(healt/healtBarMax,healtBar.localScale.y,healtBar.localScale.z);
    }
    //Robot die Animation Player
    private void Die(){
        /*for (int i = 0; i < partics.Length; i++)
        {
            partics[i].Play();
        }*/
        //this.GetComponent<Animator>().SetBool("Dead",true);
        DestroyObject();
    }

    //Robot Destroy Anim end
    public void DestroyObject(){
        Destroy(this.gameObject);
    }
}
