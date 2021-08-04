using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour
{
	
	public int totalBullets;
	public int currentBullets;
	public Text bulletText; 
	// Start is called before the first frame update
	void Start()
	{
		PlayerAttack att = gameObject.GetComponent<PlayerAttack>();
		totalBullets = att.gun.BulletCount;
		currentBullets = totalBullets;
	}

	// Update is called once per frame
	void Update()
	{
		if (currentBullets == 0)
			currentBullets = totalBullets;
	   bulletText.text = currentBullets.ToString();
	}
}
