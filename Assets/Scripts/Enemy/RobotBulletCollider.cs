using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBulletCollider : MonoBehaviour
{
    private ParticleSystem[] partic;
    private Rigidbody rigbody;

    public int gunPower = 10;
    // Start is called before the first frame update
    void Start()
    {
        partic = this.GetComponentsInChildren<ParticleSystem>();
        rigbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Robot Gun") {this.gameObject.GetComponent<BoxCollider>().enabled = false;}
        if(other.gameObject.tag != "Enemy" && other.gameObject.tag != "Robot Gun"){
            rigbody.isKinematic = true;
            for (int i = 0; i < partic.Length; i++)
            {
                partic[i].Play();
            }
            Invoke("DestroyParticle",0.3f);
        }
        if(other.gameObject.tag == "Character" || other.gameObject.tag == "isDestroyObject"){
            other.gameObject.GetComponent<CharacterFeatures>().TakeDamage(gunPower);
        }
        
    }

    private void DestroyParticle(){
        Destroy(this.gameObject);
    }
}
