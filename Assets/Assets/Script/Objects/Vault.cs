using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vault : MonoBehaviour
{
    public bool Looted; // check if the vault has been looted
    public float openTime; // how long does it take to open the vault
    public int money;
    public GameObject dialogBox;
    public Image Bar; // store the timer UI
    public float Fill;
    GameObject gameManager;
    GameController gameManagerScript;
    AudioSource audioData;
    // Start is called before the first frame update

    SpriteRenderer render; // to animate the vault doors
    public Sprite Open;
    public Sprite Closed;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        Looted = false; // By default the vault is closed   
        dialogBox.SetActive(false);
        Fill = 0;

        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameController>();

        render = GetComponent<SpriteRenderer>();
        render.sprite = Closed;
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = Fill;
    }

    public void DialogOn()
    {
        if(Looted == false)
        {
            dialogBox.SetActive(true);
        }

    }

    public void DialogOff()
    {

            dialogBox.SetActive(false);
    }

    public void openVault()
    {
        {
            gameManagerScript.totalMoney += money;
            Looted = true; // vault has been cracked
                           // give money to game manager;
            dialogBox.SetActive(false);
            render.sprite = Open;
            audioData.Play(0);
        }
    }
}
