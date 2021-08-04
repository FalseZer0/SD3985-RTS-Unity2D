using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class PlayerHealth : MonoBehaviour
{

	public int startingHealth = 100;
	public int currentHealth;
	public int startingArmor = 100;
	public int currentArmor;
	public bool damaged;
	public bool isDead;
	AudioSource playerAudio;
	private GameObject gameController;  // fame controller object
	private GameController gameManagerScript; // Refer to the enemy manager script
	private Player PlayerScript;
	private GameObject Player;
	private GameObject active;
	public bool isSafe = false;
	

	//Animation
	Animator animator;
	public GameObject MC;
	//private Rigidbody2D myScriptsRigidbody2D;
	private CircleCollider2D myCircleCollider;
	private Rigidbody2D rigidBody;
	private NavMeshAgent navMesh;
	private SpriteRenderer spriteRenderer;
	private GameObject forHealth;
	private Canvas canva;
	private GameObject Flash;
	//
	[SerializeField]
	GameObject god;
	GameController godc;

	//Ability Value
	public int HH = 0;
	

	
	void Start()
	{
		//ramos list
		godc = god.GetComponent<GameController>();
		//Animation
		MC = gameObject.transform.parent.gameObject;
		animator = MC.GetComponent<Animator>();
		//myScriptsRigidbody2D = MC.GetComponent<Rigidbody2D>();
		myCircleCollider = MC.GetComponent<CircleCollider2D>();
		rigidBody = MC.GetComponent<Rigidbody2D>();
		navMesh = MC.GetComponent<NavMeshAgent>();
		spriteRenderer = MC.GetComponent<SpriteRenderer>();
		forHealth = MC.transform.GetChild(0).gameObject;
		active = MC.transform.GetChild(4).gameObject;
		if (HH == 1)
		{
			startingHealth = 150;
		}
		else
		{
			startingHealth = 100;
		}
		currentHealth = startingHealth;
		currentArmor = startingArmor;
	}
	

	void Awake()
	{
		//HH = PlayerPrefs.GetInt("IsHHsold");

		playerAudio = GetComponent<AudioSource>();
		gameController = GameObject.Find("GameManager");
		gameManagerScript = gameController.GetComponent<GameController>();
		isDead = false;
		isSafe = false;
		//col = gameObject.GetComponentInChildren<CircleCollider2D>();
	}


	void Update()
	{
		if (currentHealth <= 0 && !isDead)
		{
			gameObject.tag = "sss";
			godc.RemovePlayer(gameObject);
			active.SetActive(false);
			currentHealth = 0;
			isDead = true;
			animator.SetBool("Death", true);
			//Destroy(myScriptsRigidbody2D);
			Destroy(myCircleCollider);
			Destroy(GetComponent<CircleCollider2D>());
			Destroy(forHealth);
			Destroy(Flash);
			MC.GetComponent<Player>().enabled = false;
			MC.GetComponent<PlayerAttack>().enabled = false;
			//Destroy(transform.parent.gameObject.GetComponent<SpriteRenderer>(),1.0f);
			Invoke("DestroyEverything", 5f);
			if (isSafe == false)
			{
				gameManagerScript.playerAlive--;
			}
			gameManagerScript.realPlayerCounter--;

		}
		if (currentHealth > startingHealth)
		{
			currentHealth = startingHealth;
		}
	}


	public void TakeDamage(int amount)
	{
		damaged = true;
		if (currentArmor > 0)
		{ currentArmor -= amount; }
		else
			{
			currentHealth -= amount;

			if (currentHealth <= 0 && !isDead)
			{
				Debug.Log("Dead");       
				
			}
		}
		
	}

	void DestroyEverything()
	{
		navMesh.enabled = false;
		spriteRenderer.enabled = false;
		
	}
}
