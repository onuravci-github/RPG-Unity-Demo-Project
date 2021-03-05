using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShot : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletReloadTime;
    public float ammoReloadTime;
    public int maxAmmo;
    private int ammo;
    public float CharacterFindSpeed;

    public GameObject shotObject;
    public EnemyFeatures enemyFeatures;

    private Vector3 characterPosition;
    private Vector3 distance;

    public bool notShot = true;
    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        enemyFeatures = this.GetComponentInParent<EnemyFeatures>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterPositionUpdate(){
        if(!notShot){ characterPosition = EnemyFeatures.CharacterObject.transform.position + EnemyFeatures.CharacterObject.GetComponent<Rigidbody>().velocity/5; }
    }

    public void CancelShot(){
        notShot = true;
        CancelInvoke("ShotStartRepeat");
        CancelInvoke("CharacterPositionUpdate");
    }

    public void ShotStart(){
        notShot = false;
        characterPosition = EnemyFeatures.CharacterObject.transform.position;
        InvokeRepeating("ShotStartRepeat",CharacterFindSpeed,bulletReloadTime);
        InvokeRepeating("CharacterPositionUpdate",CharacterFindSpeed,CharacterFindSpeed);
    }

    public void ShotStartRepeat(){
        if(!(enemyFeatures.isShotStart )){CancelShot();}
        else { 
            if(!notShot){
                if(ammo != 0 ){
                    var shot = Instantiate(shotObject,transform.position,Quaternion.identity);
                    distance = characterPosition - shot.transform.position;
                    shot.transform.rotation = Quaternion.Slerp(shot.transform.rotation,Quaternion.LookRotation(distance),1);
                    shot.GetComponent<Rigidbody>().AddForce(distance.normalized*bulletSpeed*Time.deltaTime, ForceMode.Impulse);
                    ammo--; if(ammo == 0 ){ AmmoReset(); CancelShot(); notShot = true; Invoke("RestartShot",ammoReloadTime); }
                 } 
            }
        }
    }
    public void RestartShot(){
        characterPosition = EnemyFeatures.CharacterObject.transform.position;
        InvokeRepeating("ShotStartRepeat",CharacterFindSpeed,bulletReloadTime);
        InvokeRepeating("CharacterPositionUpdate",CharacterFindSpeed,CharacterFindSpeed);
        notShot = false;
    }

    public void AmmoReset(){
        ammo = maxAmmo;
    }



}
