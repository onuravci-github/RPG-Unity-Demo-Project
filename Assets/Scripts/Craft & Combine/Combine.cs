using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    public GameObject[] combineElements;

    public static int iscomplate = 0;
    public static int complateNumb;
    public static GameObject activeElement;
    public static float firstPositionY;
    public Vector3 position;

    public Camera piCamera;
    // Start is called before the first frame update
    void Start()
    {
        complateNumb = combineElements.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0) ){
            if(activeElement)Destroy(activeElement.gameObject);
            activeElement = null;
        }
        if(Input.GetKey(KeyCode.Mouse0) && activeElement){
            // ;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
             if (Physics.Raycast(ray, out hit,Mathf.Infinity))
             {
                 position = hit.point;
                 position.y = firstPositionY*1.01f;
             }
             activeElement.gameObject.transform.position = position;
        }
    }



}
