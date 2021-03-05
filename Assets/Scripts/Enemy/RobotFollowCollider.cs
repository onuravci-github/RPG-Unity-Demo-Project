using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFollowCollider : MonoBehaviour
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

    // Robot can't Shot Character
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Character"){
            enemyFeatures.isFollow = false;
        }
    }
    // Robot can  Shot Character GUN!
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Character"){
            enemyFeatures.isFollow = true;
            enemyFeatures.isFightStart = true;
            enemyFeatures.RotateChangeStart();
            enemyFeatures.CancelRotateChangeStart();
        }
    }
}
