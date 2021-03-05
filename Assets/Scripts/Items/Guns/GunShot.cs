using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Merminin hızı ve açısının belirlendiği script
public class GunShot : MonoBehaviour
{

    public GameObject shotObject;
    public Transform instantObject;
    public Camera fpsCamera;

    //Particle System
    private ParticleSystem[] partic;
    private Rigidbody rigbody;

    public Transform rotationObjectX;
    public Transform rotationObjectY;

    //Gun BulletShot Speed
    [SerializeField] [Range(50, 300)] int BulletSpeed = 100;
    

    private Quaternion quartenion = new Quaternion(0,0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) &&  CharacterMovement.CharacterControl   ){
            CreateShot();
        }
    }


    private void CreateShot(){
        //Instantiate(shotObject,cursorTransform.transform.position,quartenion,transform);
        Ray ray = fpsCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        Vector3 targetPoint = new Vector3(0,0,0);
        if(Physics.Raycast(ray, out hit,Mathf.Infinity)){
            targetPoint = hit.point;
        }
        else{
            targetPoint = ray.GetPoint(75f);
        }
        targetPoint = ray.GetPoint(75f);
        Vector3 distance = (targetPoint - instantObject.position);
        //Add forces to bullet
        var shot = Instantiate(shotObject,instantObject.position,quartenion);
        shot.GetComponent<Rigidbody>().AddForce(distance.normalized*BulletSpeed*Time.deltaTime, ForceMode.Impulse);
        shot.transform.eulerAngles = new Vector3(rotationObjectX.eulerAngles.x,rotationObjectY.eulerAngles.y,0);

    }





}
