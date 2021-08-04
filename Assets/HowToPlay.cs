using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    private void Start()
    {
        GameObject.Find("menuMusic").GetComponent<musicMenu>().menuPlayMusic();//
    }
    public void OpenPanel()
    {
        if(Panel != null)
        {
            Panel.SetActive(true);
        }
    }
}
