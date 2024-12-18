using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;

    private void Update() {
        if(Input.GetKey(KeyCode.Escape)){
            pauseMenu.SetActive(true);
            player.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1;
    }

    public void RestartGame(){
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void goToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit(){
        Application.Quit();
    }
}
