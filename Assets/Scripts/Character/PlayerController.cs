using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Karakterin dönmesini sağlayan
public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    [SerializeField] bool lockCursor = true;

    float cameraRotateValue = 0.0f;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    void Start()
    {
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        if(CharacterMovement.CharacterControl){UpdateCharacterRotation();}
        
    }

    void UpdateCharacterRotation()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraRotateValue -= currentMouseDelta.y * mouseSensitivity;
        cameraRotateValue = Mathf.Clamp(cameraRotateValue, -50.0f, 35.0f);

        if(cameraRotateValue < 35 && cameraRotateValue > -50){
            playerCamera.localEulerAngles = Vector3.right * cameraRotateValue;
        }
        else if(cameraRotateValue > 35){
            playerCamera.localEulerAngles= new Vector3(34,0,0);
        }
        else if(cameraRotateValue < -50)
        {
            playerCamera.localEulerAngles= new Vector3(-49,0,0);
        }
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

}
