using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineElement : MonoBehaviour
{
    public bool mainElement;
    public bool isBox;

    public int objectNumb;
    public int elementNumb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnMouseDown() {
        if(mainElement){
            Combine.activeElement = Instantiate(this.gameObject,this.transform.position,this.transform.rotation,transform.parent);
            Combine.activeElement.GetComponent<BoxCollider>().enabled = false;
            Combine.activeElement.transform.localScale = transform.localScale;
            Combine.firstPositionY = this.transform.position.y;
            }
        else{

        }
    }
    private void OnMouseEnter() {
        if(!mainElement){
            if(Combine.activeElement){
                if(elementNumb == Combine.activeElement.GetComponent<CombineElement>().elementNumb){
                    this.GetComponentInParent<Combine>().combineElements[objectNumb].SetActive(true);
                    Combine.iscomplate++;
                    Destroy(Combine.activeElement);
                    Combine.activeElement = null;
                    Destroy(this.gameObject);
                }
            }
            
        }
    }

}
