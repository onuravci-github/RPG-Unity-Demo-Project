using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sandığın içinden çıkan eşyaları dışarı atma simulasyonu
public class ParticleSystemControl : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem[] particleSystems;

    public GameObject[] rewardObject;
    private Quaternion quaternion = new Quaternion(0,0,0,0);

    private float InvokeTime = 0.1f;
    private int objectNumb = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Start",true);
        }
        
    }

    public void ParticleStart(){
        
        animator.SetBool("Start",false);
        foreach (var item in particleSystems)
        {
            item.Play();
        }
        for (int random = 0; random < 1; random++)
        {
           Invoke("CreateObject",0.1f);
        } 
    }

    public void DestroyObject(){
        Destroy(this.gameObject);
    }

    public void CreateObject(){
        foreach (var item in rewardObject)
        {
            Invoke("CreateObjectSlow",InvokeTime);
            InvokeTime += 0.1f;
            
        }
        
        //a.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-0.3f,0.3f),0.2f,Random.Range(-0.3f,0.3f)),ForceMode.Impulse);
    }

    public void CreateObjectSlow(){
            var a = Instantiate(rewardObject[objectNumb],this.transform.position,quaternion);
            a.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f,1f),12,Random.Range(-1f,1f)),ForceMode.Impulse);
            objectNumb++;
    }
}
