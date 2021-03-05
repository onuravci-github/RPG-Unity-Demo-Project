using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Menulerdeki sayfaları geçmek için
public class PageButtons : MonoBehaviour
{
    // 3 tane    1.sayfadayız   
    public int pageSize;
    public int pageNumber;

    public Text pageText;

    public string[] pageString;

    public GameObject[] pageObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PreviousPage(){
        if(pageNumber <= pageSize && pageNumber != 0){ 
            for (int page = 0; page <= pageSize; page++) 
            {
                if(page == pageNumber-1) { pageObjects[page].SetActive(true); pageText.text = pageString[page]; }
                else pageObjects[page].SetActive(false); 
            }
            if(pageNumber != 0) pageNumber -= 1; 
        }
        Debug.Log(pageNumber);
        
    }
    public void NextPage(){
        if(pageNumber < pageSize && pageNumber != pageSize){
            for (int page = pageSize; page >= 0; page--)
            {
                if(page == pageNumber+1) { pageObjects[page].SetActive(true); pageText.text = pageString[page]; }
                else pageObjects[page].SetActive(false);
            }  
            if(pageNumber != pageSize) pageNumber += 1; 
        }
        Debug.Log(pageNumber);
    }
    
}
