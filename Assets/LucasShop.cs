using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LucasShop : MonoBehaviour
{
    int totalMoney;
    GameObject moneyText;
    private Text totalMoneyText;
    //public Text totalMoneyText;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    //Gun Buttons
    public Button GunButton1;
    public Button GunButton2;
    public Button GunButton3;


    //Check if the ability has already been sold
    int isLucasFMsold;
    int isLucasHDsold;
    int isLucasFUsold;
    int isLucasHHsold;

    //Check if the guns has already been sold
    int isLucasGun1Sold;
    int isLucasGun2Sold;
    int isLucasGun3Sold;

    //Stuff Gameobjects
    GameObject FM;
    GameObject HD;
    GameObject FU;
    GameObject HH;

    //Gun GameObjects
    GameObject Gun1;
    GameObject Gun2;
    GameObject Gun3;


    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("menuMusic").GetComponent<musicMenu>().menuPlayMusic();//
        GameObject.Find("gameMusic").GetComponent<musicGame>().gameStopMusic();//

        totalMoney = PlayerPrefs.GetInt("totalMoney");
        moneyText = GameObject.Find("totalMoneyText");
        totalMoneyText = moneyText.GetComponent<Text>();

        //Declare gameobjects
        FM = GameObject.Find("Move Faster");
        HD = GameObject.Find("Higher Damage");
        FU = GameObject.Find("Faster Unlock");
        HH = GameObject.Find("Higher health");

        //Declare Gun Objects
        Gun1 = GameObject.Find("Gun1");
        Gun2 = GameObject.Find("Gun2");
        Gun3 = GameObject.Find("Gun3");
    }

    // Update is called once per frame
    void Update()
    {
        totalMoneyText.text = totalMoney.ToString();

        //Check if the player has already bought stuffs
        isLucasFMsold = PlayerPrefs.GetInt("IsLucasFMsold");
        isLucasHDsold = PlayerPrefs.GetInt("IsLucasHDsold");
        isLucasFUsold = PlayerPrefs.GetInt("IsLucasFUsold");
        isLucasHHsold = PlayerPrefs.GetInt("IsLucasHHsold");

        if (isLucasFMsold == 0 && isLucasHDsold == 0 && isLucasFUsold == 0 && isLucasHHsold == 0 && totalMoney >= 100)
        {
            button1.interactable = true;
            button2.interactable = true;
            button3.interactable = true;
            button4.interactable = true;
        }
        else
        {
            button1.interactable = false;
            button2.interactable = false;
            button3.interactable = false;
            button4.interactable = false;
        }


        if (isLucasFMsold == 1)
        {
            HD.active = false;
            FU.active = false;
            HH.active = false;
        }
        if (isLucasHDsold == 1)
        {
            FM.active = false;
            FU.active = false;
            HH.active = false;
        }
        if (isLucasFUsold == 1)
        {
            FM.active = false;
            HD.active = false;
            HH.active = false;
        }
        if (isLucasHHsold == 1)
        {
            FM.active = false;
            HD.active = false;
            FU.active = false;
        }

        //Check if guns are sold
        isLucasGun1Sold = PlayerPrefs.GetInt("isLucasGun1Sold");
        isLucasGun2Sold = PlayerPrefs.GetInt("isLucasGun2Sold");
        isLucasGun3Sold = PlayerPrefs.GetInt("isLucasGun3Sold");

        if (isLucasGun1Sold == 0 && isLucasGun2Sold == 0 && isLucasGun3Sold == 0 && totalMoney >= 200)
        {
            GunButton1.interactable = true;
            GunButton2.interactable = true;
            GunButton3.interactable = true;
        }
        else if (isLucasGun1Sold == 0 && isLucasGun2Sold == 0 && isLucasGun3Sold == 0 && totalMoney >= 150 && totalMoney < 200)
        {
            GunButton1.interactable = true;
            GunButton2.interactable = true;
            GunButton3.interactable = false;
        }
        else if (isLucasGun1Sold == 0 && isLucasGun2Sold == 0 && isLucasGun3Sold == 0 && totalMoney >= 100 && totalMoney < 150)
        {
            GunButton1.interactable = true;
            GunButton2.interactable = false;
            GunButton3.interactable = false;
        }
        else
        {
            GunButton1.interactable = false;
            GunButton2.interactable = false;
            GunButton3.interactable = false;
        }


        if (isLucasGun1Sold == 1)
        {
            Gun2.active = false;
            Gun3.active = false;
        }

        if (isLucasGun2Sold == 1)
        {
            Gun1.active = false;
            Gun3.active = false;
        }

        if (isLucasGun3Sold == 1)
        {
            Gun1.active = false;
            Gun2.active = false;
        }
    }


    public void buyFM()
    {
        totalMoney -= 100;
        PlayerPrefs.SetInt("IsLucasFMsold", 1);
        button1.interactable = false;

    }

    public void buyHD()
    {
        totalMoney -= 100;
        PlayerPrefs.SetInt("IsLucasHDsold", 1);
        button2.interactable = false;
    }

    public void buyFU()
    {
        totalMoney -= 100;
        PlayerPrefs.SetInt("IsLucasFUsold", 1);
        button3.interactable = false;
    }

    public void buyHH()
    {
        totalMoney -= 100;
        PlayerPrefs.SetInt("IsLucasHHsold", 1);
        button4.interactable = false;
    }

    public void buyGun1()
    {
        totalMoney -= 100;
        PlayerPrefs.SetInt("isLucasGun1Sold", 1);
        GunButton1.interactable = false;
    }

    public void buyGun2()
    {
        totalMoney -= 150;
        PlayerPrefs.SetInt("isLucasGun2Sold", 1);
        GunButton2.interactable = false;
    }

    public void buyGun3()
    {
        totalMoney -= 200;
        PlayerPrefs.SetInt("isLucasGun3Sold", 1);
        GunButton3.interactable = false;
    }

    public void GoNext()
    {
        //For testing
        //Time.timeScale = 1f;

        PlayerPrefs.SetInt("totalMoney", totalMoney);
        SceneManager.LoadScene("Andre_Store");
    }
}
