using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMoneyText : MonoBehaviour
{
    private static Text text;
    private static int mainMoney = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
    }


    public static void MainMoneyADD(int value){
        mainMoney += value;
        text.text = mainMoney.ToString();
    }
}
