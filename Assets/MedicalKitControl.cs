using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MedicalKitControl : MonoBehaviour
{
    //Show Money
    int totalMoney;
    GameObject moneyText;
    private Text totalMoneyText;

    //Show Medical Kit Number
    int totalMK;
    GameObject MKtext;
    private Text KitNumberText;

    //Buy Medical Kit Button
    public Button MKbutton;


    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("menuMusic").GetComponent<musicMenu>().menuPlayMusic();//
        GameObject.Find("gameMusic").GetComponent<musicGame>().gameStopMusic();//

        totalMoney = PlayerPrefs.GetInt("totalMoney");
        moneyText = GameObject.Find("totalMoneyText");
        totalMoneyText = moneyText.GetComponent<Text>();

        totalMK = PlayerPrefs.GetInt("totalMK");
        MKtext = GameObject.Find("KitNumber");
        KitNumberText = MKtext.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Show Money Amount
        totalMoneyText.text = totalMoney.ToString();

        //Show Medical Kit Number
        KitNumberText.text = totalMK.ToString();

        if (totalMoney >= 25)
        {
            MKbutton.interactable = true;
        }
        else
        {
            MKbutton.interactable = false;
        }
    }

    public void buyMK()
    {
        totalMoney -= 50;
        totalMK += 1;
        PlayerPrefs.SetInt("totalMK", totalMK);
    }

    public void GoNext()
    {
        //For testing
        Time.timeScale = 1f;

        PlayerPrefs.SetInt("totalMoney", totalMoney);
        PlayerPrefs.SetInt("totalMK", totalMK);
        int level = PlayerPrefs.GetInt("level");
        switch (level)
        {
            case 0:
                SceneManager.LoadScene("Level 1");
                break;
            case 1:
                SceneManager.LoadScene("Level 2");
                break;
            case 2:
                SceneManager.LoadScene("Level 3");
                break;
            case 3:
                SceneManager.LoadScene("Level 4");
                break;
            default:
                SceneManager.LoadScene("Main Menu");
                break;
        }
        
    }
}
