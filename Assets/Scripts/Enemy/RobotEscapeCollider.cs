using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEscapeCollider : MonoBehaviour
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

    // Character in Area
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Character"){
            enemyFeatures.isEscape = false;
        }
    }

    //Character Escaped
    private void OnTriggerExit(Collider other) {
         if(other.gameObject.tag == "Character"){
            enemyFeatures.isEscape = true;
            if (enemyFeatures.isFightStart == true)
            {
                enemyFeatures.isFirstLocation = false;
                enemyFeatures.GoToFirstLocation();
            }
            enemyFeatures.isFightStart = false;
        }
    }
}
