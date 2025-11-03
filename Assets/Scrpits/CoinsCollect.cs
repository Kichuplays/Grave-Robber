using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CoinsCollect : MonoBehaviour
{
    public Text Coins;

    int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        Coins.text = coins.ToString() + "COINS";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoint()
    {
        coins += 1;
        Coins.text = coins.ToString() + "Points";
    }
}
