using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Altta yer alan menu butonlarını kapatıp açmamıza yarayacak script
public class MenuButtons : MonoBehaviour
{
    //Index ~ 0:Character 1:Inventory 2:Craft 3:Credit 4:Setting
    public GameObject[] menuObjects;

    public static bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            if(!menuOpen)CharacterMenuOpen();
            else MenuClose();
        }
        if(Input.GetKeyDown(KeyCode.I)){ 
            if(!menuOpen)InventoryMenuOpen();
            else MenuClose();
        }
        if(Input.GetKeyDown(KeyCode.O)){
            if(!menuOpen) CraftMenuOpen();
            else MenuClose();
        }
        if(Input.GetKeyDown(KeyCode.P)){
            if(!menuOpen)CreditMenuOpen();
            else MenuClose();
        }
        if(Input.GetKeyDown(KeyCode.V)){
            if(!menuOpen)SettingMenuOpen();
            else MenuClose();
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(menuOpen)MenuClose();
            else {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void CharacterMenuOpen(){
        CharacterMovement.CharacterControl = false;
        menuOpen = true;
        CursorControlOpen();
        menuObjects[0].SetActive(true);
        menuObjects[1].SetActive(false);
        menuObjects[2].SetActive(false);
        menuObjects[3].SetActive(false);
        menuObjects[4].SetActive(false);
    }
    public void InventoryMenuOpen(){
        CharacterMovement.CharacterControl = false;
        menuOpen = true;
        CursorControlOpen();
        menuObjects[0].SetActive(false);
        menuObjects[1].SetActive(true);
        menuObjects[2].SetActive(false);
        menuObjects[3].SetActive(false);
        menuObjects[4].SetActive(false);
    }
    public void CraftMenuOpen(){
        CharacterMovement.CharacterControl = false;
        menuOpen = true;
        CursorControlOpen();
        menuObjects[0].SetActive(false);
        menuObjects[1].SetActive(false);
        menuObjects[2].SetActive(true);
        menuObjects[3].SetActive(false);
        menuObjects[4].SetActive(false);
    }
    public void CreditMenuOpen(){
        CharacterMovement.CharacterControl = false;
        menuOpen = true;
        CursorControlOpen();
        menuObjects[0].SetActive(false);
        menuObjects[1].SetActive(false);
        menuObjects[2].SetActive(false);
        menuObjects[3].SetActive(true);
        menuObjects[4].SetActive(false);
    }
    public void SettingMenuOpen(){
        CharacterMovement.CharacterControl = false;
        menuOpen = true;
        CursorControlOpen();
        menuObjects[0].SetActive(false);
        menuObjects[1].SetActive(false);
        menuObjects[2].SetActive(false);
        menuObjects[3].SetActive(false);
        menuObjects[4].SetActive(true);
    }

    public void MenuClose(){
        CharacterMovement.CharacterControl = true;
        menuOpen = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menuObjects[0].SetActive(false);
        menuObjects[1].SetActive(false);
        menuObjects[2].SetActive(false);
        menuObjects[3].SetActive(false);
        menuObjects[4].SetActive(false);
    }

    public void CursorControlOpen(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
