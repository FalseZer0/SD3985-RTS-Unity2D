using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour
{

	public int startingHealth = 100;
	public int currentHealth;
	public bool damaged;
	public bool isDead;
	float delay = 3f;
	AudioSource playerAudio;
	private EnemyManager enemyManager;

	//Animation
	Animator animator;


	void Awake()
	{
		currentHealth = startingHealth;
		playerAudio = GetComponent<AudioSource>();
		isDead = false;
		enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

		//Animation
		animator = gameObject.GetComponent<Animator>();
	}


	void Update()
	{
		if (currentHealth <= 0 && !isDead)
		{
			isDead = true;
			animator.SetBool("Death", true);
			Debug.Log("-------Dead------");
			DestroyObject(gameObject,3.0f);
			enemyManager.enemyCount--;
		}
	}


	public void TakeDamage(int amount)
	{
		StartCoroutine(decrehp(amount));
		
	}
	IEnumerator decrehp(int amount)
	{
		currentHealth -= amount;
		//Debug.Log(currentHealth);
		yield return new WaitForSeconds(1f);
	}
	
}
