using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	//muzzle flash
	public GameObject muzzleFlash;
	[Range(0,5)]
	public int framesFlash = 1;

	//
	public float higherDamage=1; 
	public Guns gun;
	[SerializeField]
	int damage;
	BulletCount bullets;
	//float timeBetweenAttacks = 1f;
	float timeBetweenAttacks;
	float t1;
	float t2;
	//shoot
	public Transform firePoint;
	RaycastHit2D targetCol;
	public LineRenderer lineRenderer;
	//---------
	bool insight;
	public GameObject enemySpotted;
	[SerializeField]
	Rigidbody2D rb2d;
	private Vector2 mousePosition;
	[SerializeField]	
	GameObject target;
	Vector2 start;
	Vector2 direction;
	[SerializeField]
	private LayerMask IgnoreMe;
	private Player player;//reference to player script
	public bool enemyClicked;
    AudioSource audioData;
    public enum States

	{
		Auto,
		Control,
	}
	public States state;

	//Ability value
	public int HD = 0;

	private void Awake()
	{
        audioData = GetComponent<AudioSource>();
        if (gun == null)
		{
			gun = new DefaultGun();//in case if manager failed to assign a weapon
		}
		timeBetweenAttacks = gun.Delay;
		damage = (int)(gun.Damage*higherDamage);
		bullets = gameObject.GetComponent<BulletCount>();
		//
		rb2d = GetComponent<Rigidbody2D>();
		player = GetComponent<Player>();
		//active player
		if (player.enabled==true)
		{
			state = States.Control;
		}
		else
		{
			//passive player
			state = States.Auto;
		}

		//Check if the player has the ability "Higher Damage"
		//HD = PlayerPrefs.GetInt("IsHDsold");
	   
	}
	// Update is called once per frame
	void Update()
	{
		//Debug.Log(gameObject+" " + player);
		//update on current status about player activeness
		if (player.enabled == true)
		{
			//active
			state = States.Control;
		}
		else
		{
			//passive player
			state = States.Auto;
		}
		switch (state)
		{
			case States.Control:
				ControlAttack();
				break;
			case States.Auto:
				AutoAttack();
				break;
			default:break;
		}
	}

	IEnumerator Shoot(RaycastHit2D sightTest)
	{
		Debug.Log(sightTest.collider+"sightcol");
		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, sightTest.point);
		if (enemySpotted != null)
		{
			if (Vector2.Distance(enemySpotted.transform.position, transform.position) > 5f)
			{
				//distance long enough dont focus on the enemy
				enemySpotted = null;
			}
		}
		//ray shows for a sec and disappears
		lineRenderer.enabled = true;
		muzzleFlash.SetActive(true);
        audioData.Play(0);
        //wait 1 frame		
        //make it dependable on the gun type in future
        yield return new WaitForSeconds(0.05f);
		lineRenderer.enabled = false;
		muzzleFlash.SetActive(false);
	}

	void AutoAttack()
	{
		if (target != null)
		{
			if (Vector2.Distance(target.transform.position, transform.position) > 5f)
			{
				//distance long enough dont focus on the enemy
				target = null;
			}
			else if (target.GetComponentInParent<EnemyHealth>().isDead)
			{
				target = null;
			}
		}
		if (target != null)
		{
			//auto-rotate towards target
			Vector2 look = target.transform.parent.gameObject.GetComponent<Rigidbody2D>().position - rb2d.position;
			float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;//-90f														  //rb2d.rotation = angle;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10);
			//Debug.Log("I " + gameObject + " am passive and Shooting " + target.transform.parent);
			//shooting particles shown
			//targetcol is same as target but former is the 2dhit while latter is collider lol

			//hp deduction
			EnemyHealth hp = target.GetComponentInParent<EnemyHealth>();
			t2 += Time.deltaTime;
			if (t2 >= timeBetweenAttacks)
			{
				if (targetCol.collider.gameObject.tag == "Enemy")
					StartCoroutine(Shoot(targetCol));
				t2 = 0f;
				hp.TakeDamage(damage);
				bullets.currentBullets--;


				//if (HD == 1)
				//{
				//	hp.TakeDamage(10);//timer
				//	Debug.Log("With HD, the damage now is 10");
				//}
				//else
				//{
				//	hp.TakeDamage(5);//timer
				//}
				
			}
		}
	}
	void ControlAttack()
	{
		//left mouse click
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log(1);
			if (ClickedGameobject() != null)
			{
				Debug.Log(2);
				//smth was clicked
				if (ClickedGameobject().tag=="Enemy")
				{
					Debug.Log(3);
					//its an enemy
					GameObject enemy = ClickedGameobject();
					//Debug.Log(enemy);
					//take a clicked object
					mousePosition = Input.mousePosition;
					mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
					Vector2 lookdir = mousePosition - rb2d.position;
					float distance = 5f;
					RaycastHit2D sightTest = Physics2D.Raycast(transform.position, lookdir.normalized, distance, ~IgnoreMe);
					
					if (sightTest.collider != null)
					{
						if (sightTest.collider.gameObject != gameObject && sightTest.collider.gameObject.tag == "Enemy")
						{
							float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;//-90f
							rb2d.rotation = angle;
							enemySpotted = sightTest.collider.gameObject;
							enemyClicked = true;
						}
						else
						{
							enemySpotted = null;//reset enemyspotted if clicked elsewhere
							enemyClicked = false;//?
						}
					}
				}
				else
				{
					enemySpotted = null;
					Debug.Log("reset enemy position");//reset enemyspotted if clicked elsewhere
					enemyClicked = false;//?
				}
			}
		}
		//if its still selected keep shooting
		if (enemySpotted != null)
		{

			Vector2 look = enemySpotted.transform.parent.gameObject.GetComponent<Rigidbody2D>().position - rb2d.position;//direction
			float distance = 5f;
			RaycastHit2D sightTest = Physics2D.Raycast(start, look.normalized, distance, ~IgnoreMe);
			if (Vector2.Distance(enemySpotted.transform.position, transform.position) > 5f)
			{
				//distance long enough dont focus on the enemy
				enemySpotted = null;
			}
			else if (enemySpotted.GetComponentInParent<EnemyHealth>().isDead)
			{
				enemySpotted = null;
			}
			else
			{

				
				EnemyHealth hp = enemySpotted.GetComponentInParent<EnemyHealth>();
				t1 += Time.deltaTime;
				if (t1 >= timeBetweenAttacks)
				{
					t1 = 0f;
					//if (HD == 1)
					//{
					//	hp.TakeDamage(10);//timer
					//	Debug.Log("With HD, the damage now is 10");
					//}
					//else
					//{
					//	hp.TakeDamage(5);//timer
					//}
					hp.TakeDamage(damage);
					bullets.currentBullets--;
					StartCoroutine(Shoot(sightTest));
				}
				
			}
		}
		
	

	}
	void OnTriggerStay2D(Collider2D collision)
	{
		//enemy entered the area of sight
		if(collision.gameObject.tag == "Enemy")
		{
			start = transform.position;
			direction = collision.gameObject.transform.position - transform.position;
			float distance = 5f;
			Debug.DrawRay(start, direction, Color.green, 1);
			RaycastHit2D sightTest = Physics2D.Raycast(start, direction.normalized, distance, ~IgnoreMe);
			if(sightTest.collider!=null)
			{
				//hits enemy
				if(sightTest.collider.gameObject!=gameObject&&sightTest.collider.gameObject.tag=="Enemy")
				{
					//enemy detected
					target = sightTest.collider.gameObject;//used by auto
					targetCol = sightTest;
					//if(state==States.Auto) enemySpotted = sightTest.collider.gameObject;
				}
				else
				{
					//if(state==States.Auto)	enemySpotted = null;
					target = null;
				}
			}
			else
			{
				//if (state == States.Auto) enemySpotted = null;
				target = null;
			}
		}

	}

	GameObject ClickedGameobject()
	{
		//return clicked object
		GameObject clicked=null;
		Collider2D clicked_collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		try
		{
			clicked = clicked_collider.gameObject;
		}
		catch { Debug.Log("null"); }
		return clicked;
	}
}
