using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages playable characters switches

public class GameControl : MonoBehaviour
{
	
	public GameObject[] Players;
	[SerializeField]
	GameObject CurrentPlayer;
	float SwitchCooldown;
	int count;
	Player player;
	GameObject playerNamecard;
	// Start is called before the first frame update
	void Start()
	{
		
		//for (int i = 1; i < Players.Length; i++)
		//{
		//	Players[i].GetComponent<Player>().enabled = true;
		//}
		//cooldown for switch
		SwitchCooldown = 1f;
		count=1;
		for (int i= 1; i < Players.Length; i++)
		{
			Players[i].GetComponent<Player>().enabled = false;
			Players[i].transform.GetChild(4).gameObject.SetActive(false);
		}
		CurrentPlayer = Players[0];
		playerNamecard = CurrentPlayer.GetComponent<Player>().namecard;
		playerNamecard.transform.Translate(0, 25, 0);
		CurrentPlayer.transform.GetChild(4).gameObject.SetActive(true);



	}

	private void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(TimerRoutine());

		}
	}
	private IEnumerator TimerRoutine()
	{
		//code can be executed anywhere here before this next statement 
		SwitchPlayer();
		yield return new WaitForSeconds(5); //code pauses for 5 seconds
											//code resumes after the 5 seconds and exits if there is nothing else to run

	}
	public void SwitchPlayer()
	{
		if (count > Players.Length - 1) count = 0; // reset the count
		playerNamecard = CurrentPlayer.GetComponent<Player>().namecard;
		playerNamecard.transform.Translate(0, -25, 0);
		CurrentPlayer.GetComponent<Player>().enabled = false;
		CurrentPlayer.GetComponent<LineRenderer>().enabled = false;
		CurrentPlayer.transform.GetChild(4).gameObject.SetActive(false);
		CurrentPlayer = Players[count];
		CurrentPlayer.transform.GetChild(4).gameObject.SetActive(true);
		CurrentPlayer.GetComponent<Player>().enabled = true;
		CurrentPlayer.GetComponent<LineRenderer>().enabled = true;
		playerNamecard = CurrentPlayer.GetComponent<Player>().namecard;
		playerNamecard.transform.Translate(0, 25, 0);
		count++;
	}
}
