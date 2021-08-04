using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmHandle : MonoBehaviour
{
    public bool Deactivated; // check if the vault has been looted
    public bool On;
    public float turnOffTime; // how long does it take to open the vault
    public GameObject dialogBox;
    public Image Bar; // store the timer UI
    public float Fill;
    public GameObject alarmControlled;
    AlarmTrigger alarmScript;

    // Start is called before the first frame update
    void Start()
    {
        Deactivated= false; // By default the vault is closed   
        dialogBox.SetActive(false);
        Fill = 0;
        alarmScript = alarmControlled.GetComponent<AlarmTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = Fill;
        On = alarmScript.On;
    }

    public void DialogOn()
    {
        if (Deactivated == false)
        {
            dialogBox.SetActive(true);
        }

    }

    public void DialogOff()
    {

        dialogBox.SetActive(false);
    }

    public void alarmOff()
    {
        {
            Deactivated = true; // alarm off
            dialogBox.SetActive(false);
            alarmScript.Deactivated = true; // sound off
            alarmScript.On = false;
            Destroy(alarmControlled.transform.GetChild(0).gameObject);
        }
    }
}
