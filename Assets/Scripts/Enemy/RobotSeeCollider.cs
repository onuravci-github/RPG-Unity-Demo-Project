using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSeeCollider : MonoBehaviour
{
    private EnemyFeatures enemyFeatures;
    // Start is called before the first frame update
    void Start()
    {
        enemyFeatures = this.GetComponentInParent<EnemyFeatures>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Robot can't  Shot Character GUN!
    private void OnTriggerExit(Collider other) {
         if(other.gameObject.tag == "Character"){
            enemyFeatures.isSee = false;
        }
    }

    //Robot can  Shot Character GUN!
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Character"){
            enemyFeatures.isSee = true;
        }
    }
    
}
