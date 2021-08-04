using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TotalScore : MonoBehaviour
{
    int totalMoney;
    GameObject moneyText;
    private Text totalMoneyText;

    void Start()
    {
        GameObject.Find("gameMusic").GetComponent<musicGame>().gameStopMusic();//
        totalMoney = PlayerPrefs.GetInt("totalMoney");
        moneyText = GameObject.Find("totalMoneyText");
        totalMoneyText = moneyText.GetComponent<Text>();
        totalMoneyText.text = totalMoney.ToString();
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.DeleteAll();
    }

}
