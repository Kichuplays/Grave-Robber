using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class CoinsCollect : MonoBehaviour
{
    public TextMeshProUGUI Coins;

    int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        Coins.text = coins.ToString() + "COINS";
    }

   
    public void AddPoint()
    {
        coins += 1;
        Coins.text = coins.ToString() + "Points";
    }
}
