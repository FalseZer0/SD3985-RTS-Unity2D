using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	//god
	public List<GameObject> targetList;


	public int totalMoney;
	public int startingMoney;
	GameObject moneyT;
	private Text moneyText;
	private Text medikitText;
	public int playerAlive;
	public int realPlayerCounter;

	public int medikit;

	//count
	int count = 0;

	//Shop System
	//Ramires
	int isRamiresFMsold;
	int isRamiresHDsold;
	int isRamiresFUsold;
	int isRamiresHHsold;
	int isRamiresGun1Sold;
	int isRamiresGun2Sold;
	int isRamiresGun3Sold;

	//Lucas
	int isLucasFMsold;
	int isLucasHDsold;
	int isLucasFUsold;
	int isLucasHHsold;
	int isLucasGun1Sold;
	int isLucasGun2Sold;
	int isLucasGun3Sold;

	//Andre
	int isAndreFMsold;
	int isAndreHDsold;
	int isAndreFUsold;
	int isAndreHHsold;
	int isAndreGun1Sold;
	int isAndreGun2Sold;
	int isAndreGun3Sold;

	GameObject gameOverScreen;
	private void Awake()
	{
		targetList = new List<GameObject>();
		//adding targets inside list
		foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Player"))
		{

			targetList.Add(fooObj);
		}
	}
	// Start is called before the first frame update
	void Start()
	{
		
		foreach (GameObject s in targetList)
		{
			Debug.Log(s.transform.parent.name);
		}
		Debug.Log(targetList.Count);
		//
		GameObject.Find("menuMusic").GetComponent<musicMenu>().menuStopMusic();//
		GameObject.Find("gameMusic").GetComponent<musicGame>().gamePlayMusic();//


		gameOverScreen = GameObject.Find("GameOverCanvas");
		gameOverScreen.SetActive(false);
		moneyT = GameObject.Find("MoneyText");
		moneyText = moneyT.GetComponent<Text>();
		medikitText = GameObject.Find("MedikitText").GetComponent<Text>();
		totalMoney = startingMoney;
		moneyText.text = startingMoney.ToString();
		medikitText.text = medikit.ToString();

		
		playerAlive = 3; // 3 players at the beginning
		realPlayerCounter = 3;


		//get the variables from store
		//For level 1, reset the PlayerPrefs at the beginning
		//for later levels, get the varialbles here
		totalMoney = PlayerPrefs.GetInt("totalMoney");
		medikit = PlayerPrefs.GetInt("totalMK");

		//Shop System
		//Ramires
		isRamiresFMsold = PlayerPrefs.GetInt("IsRamiresFMsold");
		isRamiresHDsold = PlayerPrefs.GetInt("IsRamiresHDsold");
		isRamiresFUsold = PlayerPrefs.GetInt("IsRamiresFUsold");
		isRamiresHHsold = PlayerPrefs.GetInt("IsRamiresHHsold");
		isRamiresGun1Sold = PlayerPrefs.GetInt("isRamiresGun1Sold");
		isRamiresGun2Sold = PlayerPrefs.GetInt("isRamiresGun2Sold");
		isRamiresGun3Sold = PlayerPrefs.GetInt("isRamiresGun3Sold");

		//Lucas
		isLucasFMsold = PlayerPrefs.GetInt("IsLucasFMsold");
		isLucasHDsold = PlayerPrefs.GetInt("IsLucasHDsold");
		isLucasFUsold = PlayerPrefs.GetInt("IsLucasFUsold");
		isLucasHHsold = PlayerPrefs.GetInt("IsLucasHHsold");
		isLucasGun1Sold = PlayerPrefs.GetInt("isLucasGun1Sold");
		isLucasGun2Sold = PlayerPrefs.GetInt("isLucasGun2Sold");
		isLucasGun3Sold = PlayerPrefs.GetInt("isLucasGun3Sold");

		//Andre
		isAndreFMsold = PlayerPrefs.GetInt("IsAndreFMsold");
		isAndreHDsold = PlayerPrefs.GetInt("IsAndreHDsold");
		isAndreFUsold = PlayerPrefs.GetInt("IsAndreFUsold");
		isAndreHHsold = PlayerPrefs.GetInt("IsAndreHHsold");
		isAndreGun1Sold = PlayerPrefs.GetInt("isAndreGun1Sold");
		isAndreGun2Sold = PlayerPrefs.GetInt("isAndreGun2Sold");
		isAndreGun3Sold = PlayerPrefs.GetInt("isAndreGun3Sold");

		//Assign abilities

		//guns
		//Ramires
		//isRamiresGun1Sold = PlayerPrefs.GetInt("isRamiresGun1Sold");
		//isRamiresGun2Sold = PlayerPrefs.GetInt("isRamiresGun2Sold");
		//isRamiresGun3Sold
		GameObject rama = GameObject.Find("MC_Ramires");
		PlayerAttack ramaAttack = rama.GetComponent<PlayerAttack>();
		ramaAttack.gun = new DefaultGun();
		//if not default weapon
		if (isRamiresGun1Sold == 1)
		{
			ramaAttack.gun = new Pistol();
		}
		else if (isRamiresGun2Sold==1)
		{
			ramaAttack.gun = new SubM();
		}
		else if (isRamiresGun3Sold == 1)
		{
			ramaAttack.gun = new Rifle();
		}
		//lucas
		GameObject luc = GameObject.Find("MC_Lucas");
		PlayerAttack lucatt= rama.GetComponent<PlayerAttack>();
		lucatt.gun = new DefaultGun();
		//if not default weapon
		if (isRamiresGun1Sold == 1)
		{
			lucatt.gun = new Pistol();
		}
		else if (isRamiresGun2Sold == 1)
		{
			lucatt.gun = new SubM();
		}
		else if (isRamiresGun3Sold == 1)
		{
			lucatt.gun = new Rifle();
		}
		//adnre
		GameObject an = GameObject.Find("MC_Lucas");
		PlayerAttack anatt = rama.GetComponent<PlayerAttack>();
		anatt.gun = new DefaultGun();
		//if not default weapon
		if (isRamiresGun1Sold == 1)
		{
			anatt.gun = new Pistol();
		}
		else if (isRamiresGun2Sold == 1)
		{
			anatt.gun = new SubM();
		}
		else if (isRamiresGun3Sold == 1)
		{
			anatt.gun = new Rifle();
		}
		//hd


		//Ramires
		if (isRamiresFMsold == 1)
		{
			GameObject s = GameObject.Find("MC_Ramires");
			Player ss = s.GetComponent<Player>();
			ss.FM = 1;
		}
		if (isRamiresFUsold == 1)
		{
			GameObject s = GameObject.Find("MC_Ramires");
			Player ss = s.GetComponent<Player>();
			ss.FU = 1;
		}
		if (isRamiresHHsold == 1)
		{
			GameObject s = GameObject.Find("MC_Ramires/Soul");
			PlayerHealth ss = s.GetComponent<PlayerHealth>();
			ss.HH = 1;

			PlayerHealthBar aa = s.GetComponent<PlayerHealthBar>();
			aa.HH = 1;
		}
		if (isRamiresHDsold == 1)
		{
			ramaAttack.higherDamage = 1.5f;
		}
		

		//Lucas
		if (isLucasFMsold == 1)
		{
			GameObject s = GameObject.Find("MC_Lucas");
			Player ss = s.GetComponent<Player>();
			ss.FM = 1;
		}
		if (isLucasFUsold == 1)
		{
			GameObject s = GameObject.Find("MC_Lucas");
			Player ss = s.GetComponent<Player>();
			ss.FU = 1;
		}
		if (isLucasHHsold == 1)
		{
			GameObject s = GameObject.Find("MC_Lucas/Soul");
			PlayerHealth ss = s.GetComponent<PlayerHealth>();
			ss.HH = 1;

			PlayerHealthBar aa = s.GetComponent<PlayerHealthBar>();
			aa.HH = 1;
		}
		if (isLucasHDsold == 1)
		{
			lucatt.higherDamage = 1.5f;
		}


		//Andre
		if (isAndreFMsold == 1)
		{
			GameObject s = GameObject.Find("MC_Andre");
			Player ss = s.GetComponent<Player>();
			ss.FM = 1;
		}
		if (isAndreFUsold == 1)
		{
			GameObject s = GameObject.Find("MC_Andre");
			Player ss = s.GetComponent<Player>();
			ss.FU = 1;
		}
		if (isAndreHHsold == 1)
		{
			GameObject s = GameObject.Find("MC_Andre/Soul");
			PlayerHealth ss = s.GetComponent<PlayerHealth>();
			ss.HH = 1;

			PlayerHealthBar aa = s.GetComponent<PlayerHealthBar>();
			aa.HH = 1;
		}
		if (isAndreHDsold == 1)
		{
			anatt.higherDamage = 1.5f;
		}



	}
	public void RemovePlayer(GameObject g)
	{
		//targetList = new List<GameObject>();
		//targetList.Capacity = realPlayerCounter;
		////targetList.Remove();
		//foreach (GameObject o in GameObject.FindGameObjectsWithTag("Player"))
		//{

		//}
		foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Player"))
		{
			if (fooObj.GetComponent<PlayerHealth>().currentHealth > 0)
				targetList.Add(fooObj);
		}
		Debug.Log("list updated");
	}
	// Update is called once per frame
	void Update()
	{
		moneyText.text = totalMoney.ToString();
		medikitText.text = medikit.ToString();
        Debug.Log(realPlayerCounter);
		if (realPlayerCounter <= 0)
		{
			if (count == 0)
			{
				gameOverScreen.SetActive(true);
				int level = PlayerPrefs.GetInt("level");
				if (level > 0)
				{
					int PreviousTotalMoney = PlayerPrefs.GetInt("PreviousTotalMoney");
					PlayerPrefs.DeleteAll();

					PlayerPrefs.SetInt("totalMoney", PreviousTotalMoney);
					PlayerPrefs.SetInt("totalMK", medikit);
					PlayerPrefs.SetInt("level", level);

					int test1 = PlayerPrefs.GetInt("totalMoney");
					int test2 = PlayerPrefs.GetInt("totalMK");
					int test3 = PlayerPrefs.GetInt("level");

					Debug.Log("LEVEL FAILS, THE CURRENT MONEY IS THE PREVIOUS LEVEL MONEY: " + test1);
					Debug.Log("LEVEL FAILS, THE CURRENT Medikit: " + test2);
					Debug.Log("LEVEL FAILS, THE CURRENT level: " + test3);

				}
				count++;
			}
			//Time.timeScale = 0f;
		}
	}

	public void gotoShop()
	{
		int level = PlayerPrefs.GetInt("level");
		level = level + 1;

		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("level", level);
		PlayerPrefs.SetInt("totalMoney", totalMoney);
		PlayerPrefs.SetInt("PreviousTotalMoney", totalMoney);
		PlayerPrefs.SetInt("totalMK", medikit);
		SceneManager.LoadScene("ShopTransition");
		Debug.Log("GO TO THE NEXT LEVEL, CURRENT MONEY IS " + totalMoney);
		Debug.Log("goshop" + PlayerPrefs.GetInt("level"));
	}

	public void WinCondition()
	{
		PlayerPrefs.SetInt("totalMoney", totalMoney);
		SceneManager.LoadScene("ScoreScene");
	}
	//Delete PlayerPrefs for testing
	/*
	public void Reset()
	{
		totalMoney = 0;
		medikit = 1;
		PlayerPrefs.DeleteAll();
	}
	*/
}
