using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Next : MonoBehaviour
{
    public GameObject ThisPanel;
    public GameObject PanelNext;
    // Start is called before the first frame update

    public void GoNextPanel()
    {
        if (ThisPanel != null && PanelNext != null)
        {
            ThisPanel.SetActive(false);
            PanelNext.SetActive(true);
        }
    }
}
