using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuaseMenu : MonoBehaviour
{
    // Om spelen är pausad: det är inte 
    public static bool gamePaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        // om man trycker på Escape och spelet är pausat så fortsätter spelet, annars pausar spelet.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        // Menu skärman byter till falskt för att ta bort det från skärmen, tiden fortsätter och bool byter till falskt.
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    void Pause()
    {
        //Spelet pausar genom att sätta panel active och frysser tiden i spelet,Boolen byter till sant.
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;

    }

    public void MainMenu()
    {
        // för knappen i pause meny, Det loadar scenen som heter "Main menu"
        SceneManager.LoadScene("Main menu");
    }
    public void MiniGame()
    {
        //Loadar scenen som heter "Lolipop"
        SceneManager.LoadScene("Lolipop");
    }
}
