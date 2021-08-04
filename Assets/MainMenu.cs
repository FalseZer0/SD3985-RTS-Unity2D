using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("level", 0);
        GameObject.Find("menuMusic").GetComponent<musicMenu>().menuPlayMusic();//
        GameObject.Find("gameMusic").GetComponent<musicGame>().gameStopMusic();//
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
