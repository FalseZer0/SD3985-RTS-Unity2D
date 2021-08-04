using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATM : MonoBehaviour
{
    public bool Looted; // check if the vault has been looted
    public float openTime; // how long does it take to open the vault
    public int money;
    public GameObject dialogBox;
    public Image Bar; // store the timer UI
    public float Fill;
    GameObject gameManager;
    GameController gameManagerScript;
    // Start is called before the first frame update
    AudioSource audioData;

    void Start()
    {
        Looted = false; // By default the vault is closed   
        dialogBox.SetActive(false);
        Fill = 0;
        audioData = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = Fill;
    }

    public void DialogOn()
    {
        if (Looted == false)
        {
            dialogBox.SetActive(true);
        }

    }

    public void DialogOff()
    {

        dialogBox.SetActive(false);
    }

    public void openATM()
    {
        {
            gameManagerScript.totalMoney += money;
            Looted = true; // vault has been cracked
                           // give money to game manager;
            dialogBox.SetActive(false);
            audioData.Play(0);
        }
    }
}
