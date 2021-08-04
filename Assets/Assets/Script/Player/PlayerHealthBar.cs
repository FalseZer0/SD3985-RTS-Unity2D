using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar: MonoBehaviour
{
    public Image Bar;
    public Text health;
    public Text armor;
    public float Fill;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update

    //Check if the player has the ability "Higher Health"
    //If the player has it, Fill should be divided by 150
    //Ability Value
    public int HH = 0;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        //Check if the player has bought the ability "Higher Health"
        //HH = PlayerPrefs.GetInt("IsHHsold");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HH == 1)
        {
            Fill = playerHealth.currentHealth / 150f;
        }
        else
        {
            Fill = playerHealth.currentHealth / 100f;
        }
    
        Bar.fillAmount = Fill;
        health.text = playerHealth.currentHealth.ToString();
        armor.text = playerHealth.currentArmor.ToString();
    }
}
