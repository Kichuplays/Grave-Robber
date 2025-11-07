using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour //made by Atilla
{
    [SerializeField] GameObject winnerUI;
    

    // Update is called once per frame
    void Update()
    {
        if (winnerUI.activeInHierarchy) //döljer mus-cursorn
        {
           // Cursor.visible = true;
        }
        else
        {
            //Cursor.visible = false;
        }
    }

    public void Winner() //Poppar up winner UI
    {
        winnerUI.SetActive(true);
    }

    public void Play()
    {
        winnerUI.SetActive(false);
    }

    public void Restart() //Restart knapp
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit() //Quit knapp
    {
        SceneManager.LoadScene("Main menu");
    }

    public void OpenWebsite() //Quit knapp
    {
        Application.OpenURL("https://cdn.discordapp.com/attachments/1196405309003018301/1352223532259610674/Low_Tier_Marco.gif?ex=690b234d&is=6909d1cd&hm=28989551c2e00de873cca5658c0e021ad5da73e0fd961db3b38d791deede99b2&");
    }
   

       
}
