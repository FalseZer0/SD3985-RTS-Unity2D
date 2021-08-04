using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    GameObject gameOverCanvas;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas = GameObject.Find("GameOverCanvas");
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        int level = PlayerPrefs.GetInt("level");
        if (level == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (level > 0)
        {
            SceneManager.LoadScene("Ramire_Store");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
