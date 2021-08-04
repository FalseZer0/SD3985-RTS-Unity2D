using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarCanvas : MonoBehaviour
{
    BoxCollider2D col;
    public GameObject FOWCanvas;

    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FOWCanvas.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        FOWCanvas.SetActive(true);
    }
}
