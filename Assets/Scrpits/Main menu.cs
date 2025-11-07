using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    // Gjord av Aiden
    public void PlayGame()
    {
        // loadar scenen i build index som är efter main menu som är "Test Build"
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quitgame()
    {
        // spelet stänger av
        Application.Quit();
    }

    
}
