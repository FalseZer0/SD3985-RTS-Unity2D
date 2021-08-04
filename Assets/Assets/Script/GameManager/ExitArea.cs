using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D col; 
    public int playerNum;
    private GameController gameManagerScript; // Refer to the enemy manager script
    private bool playerExit;
    private int level;
    AudioSource audioData;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameController>();
        level = PlayerPrefs.GetInt("level");
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerNum > 0 && playerNum == gameManagerScript.playerAlive)
        {
            audioData.Play(0);
            
            if (level == 3)
            {
                gameManagerScript.WinCondition();
            }
            else
                gameManagerScript.gotoShop();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerHealth health = col.GetComponent<PlayerHealth>();
            health.isSafe = true;
            if (health.isDead == false)
            { playerNum++; }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerHealth health = col.GetComponent<PlayerHealth>();
            health.isSafe = false;
            playerNum--;
        }
    }
}
