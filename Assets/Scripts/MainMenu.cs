using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);    
    }

    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
