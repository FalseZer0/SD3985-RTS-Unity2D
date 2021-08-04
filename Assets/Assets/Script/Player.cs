using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	//sight
	[SerializeField]
	Rigidbody2D rb2d;
	//[SerializeField]
	//LayerMask IgnoreMe;
	//Attack
	[SerializeField]
	private PlayerAttack playerAttack;
	//movement
	float stuckDistance;
	float walkStuck;
	private Vector2 mousePosition;
	Transform transform;
	private NavMeshAgent agent;
	private NavMeshPath path;
	private LineRenderer lineRenderer;
	float maxMoveDistance = 5f;
	Vector2 vectoredCoordinate;
	CircleCollider2D col; // collider of the player used for sight and detection
	private Vault vaultScript; // refer to the vault script
	private GameObject vault;
	private ATM atmScript; // refer to the vault script
	private GameObject atm;
	float openTimer; // timercounter
	bool EisPressed; // to determine if the Key E is pressed
	Rigidbody2D player;
	private GameObject alarm;
	private AlarmTrigger alarmScript;
	private AlarmHandle alarmHandle;
	private GameController gameManagerScript;
	public GameObject namecard;

	BulletCount countBullets;
	PlayerHealth health;

	//Animation
	Animator animator;

	//Ability value
	public int FM = 0;
	public int FU = 0;

	public bool isBlocked;
	enum State
	{
		Chill,
		Move,
		Attack,
	}
	private State state;
	//------
	// Start is called before the first frame update
	void Start()
	{
		// Testing
		//Debug.Log(gameObject.name + "  :  " +FM);

		//necessary for normal mesh agent behavior
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
		//Check if the player has the ability "Faster Movement"
		//FM = PlayerPrefs.GetInt("IsFMsold");
		if(FM == 1)
		{
			agent.speed = 4.0f;
		}
		else
		{
			agent.speed = 3.0f;
		}

		//Check if the player has the ability "Faster Unlock"
		//FU = PlayerPrefs.GetInt("IsFUsold");


		transform = GetComponent<Transform>();
		
		lineRenderer = GetComponent<LineRenderer>();
		//outline

		countBullets = GetComponent<BulletCount>();
		col = gameObject.GetComponentInChildren<CircleCollider2D>();
		player = GetComponent<Rigidbody2D>();
		playerAttack = GetComponent<PlayerAttack>();
		health = transform.Find("Soul").GetComponent<PlayerHealth>();

		//Animation
		animator = GetComponent<Animator>();

	}
	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		state = State.Chill;
		path = new NavMeshPath();
		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameController>();
	}

	// Update is called once per frame
	void Update()
	{
		
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
		//blocked state
		//if (isBlocked) state = State.Blocked;
		//else state = State.Chill;
		vectoredCoordinate = transform.position;
		//Mouse
		if (Input.GetMouseButtonDown(1)&&state.Equals(State.Chill)&& health.isDead == false)
		{
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			Player.GetPath(path,vectoredCoordinate,mousePosition, NavMesh.AllAreas);
			//Debug.Log(Player.GetPathLength(path));

			if (Player.GetPathLength(path) <= maxMoveDistance && EisPressed == false)
			{
				
				state = State.Move;
		  
			}
			else
			{
				Debug.Log("Cant go that far");
			}
		}
		//State machine
		switch (state)
		{
			//case State.Blocked:
			//	//not used
			//	break;
			case State.Chill:
				//do nothing
				break;
			case State.Move:
				agent.SetDestination(mousePosition);
				//draw outline
				lineRenderer.positionCount = agent.path.corners.Length;
				lineRenderer.SetPositions(agent.path.corners);
				lineRenderer.enabled = true;
				////rotate towards the target
				if (playerAttack.enemySpotted==null)
				{
					//if no enemy spotted
					Vector3 vectorToTarget = mousePosition - vectoredCoordinate;
					float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
					Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
					transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2);
					//animator.SetBool("Walking", true);
				}
				else
				{
					//enemy spotted focus on the enemy
					Vector2 look = playerAttack.enemySpotted.transform.parent.gameObject.GetComponent<Rigidbody2D>().position - rb2d.position;
					float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;//-90f														  //rb2d.rotation = angle;
					Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
					transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10);
				}


				//Vector3 vectorToTarget = mousePosition;
				//float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
				//Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				//transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2);
				if(agent.remainingDistance<=1f)
				{
					stuckDistance = agent.remainingDistance;

					if (Mathf.Abs(stuckDistance - agent.remainingDistance) <= 0.3f)
					{
						walkStuck += Time.deltaTime;
						if (walkStuck >= 2f)
						{
							agent.isStopped = true;
							agent.ResetPath();
							walkStuck = 0;
							state = State.Chill;
						}

						

					}
				}
				if (!agent.pathPending)
				{
					if (agent.remainingDistance <= agent.stoppingDistance)
					{
						
						if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
						{
							
							lineRenderer.enabled = false;
							state = State.Chill;
							//animator.SetBool("Walking", false);
						}
					}
				}
				break;
			default: break;
		}
		/*if (state.Equals(State.Chill))
		{

		lineRenderer.positionCount = agent.path.corners.Length;
		lineRenderer.SetPositions(agent.path.corners);
		lineRenderer.enabled = true;
		}
		else
		{
			lineRenderer.enabled = false;
		}*/
		if (Input.GetKey(KeyCode.R))
		{
			countBullets.currentBullets = countBullets.totalBullets;

		}

		if (Input.GetKey(KeyCode.E))
		{
			EisPressed = true;
		}
		else
		{
			EisPressed = false;  
			openTimer = 0;
		}

		if (Input.GetKeyDown(KeyCode.H))
		{
			if (gameManagerScript.medikit > 0 && health.currentHealth < health.startingHealth)
			{
				health.currentHealth += 50;
				gameManagerScript.medikit--;
			}
		}

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Vault")
		{
			vault = other.gameObject;
			vaultScript = vault.GetComponent<Vault>();
			openTimer = 0;
			vaultScript.Fill = 0;
			if (Vector2.Distance(other.transform.position, transform.position) < 2f)

			{ vaultScript.DialogOn(); }
		}

		if (other.gameObject.tag == "atm")
		{
			atm = other.gameObject;
			atmScript = atm.GetComponent<ATM>();
			openTimer = 0;
			atmScript.Fill = 0;
			if (Vector2.Distance(other.transform.position, transform.position) < 2f)

			{ atmScript.DialogOn(); }
		}
		if (other.gameObject.tag == "Alarm")
		{
			alarm = other.gameObject;
			alarmScript = alarm.GetComponent<AlarmTrigger>();
		}

		if (other.gameObject.tag == "AlarmHandle")
		{
			alarmHandle = other.gameObject.GetComponent<AlarmHandle>();
			if (alarmHandle.On == false)
			{
				openTimer = 0;
				alarmHandle.Fill = 0;
				alarmHandle.DialogOn();
			}
		}
		

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Vault")
		{
			vaultScript.DialogOff();
			vaultScript.Fill = 0;
		}

		if (other.gameObject.tag == "atm")
		{
			atmScript.DialogOff();
			atmScript.Fill = 0;
		}

		if (other.gameObject.tag == "AlarmHandle")
		{
			alarmHandle.DialogOff();
			alarmHandle.Fill = 0;
		}

		

	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			openTimer = 0;
		}
		if (col.gameObject.tag == "Vault")
		{
			if (vaultScript.Looted == false)
			{

				if (EisPressed == true && Vector2.Distance(col.transform.position, transform.position) < 1f)
				{
					//if the player has the ability "Faster Unlock", the openTimer will increase faster
					if (FU == 1)
					{
						openTimer += 2.0f;
					}
					else
					{
						openTimer++;
					}
					
					vaultScript.Fill = openTimer / vaultScript.openTime;
					if (openTimer >= vaultScript.openTime)
					{
						vaultScript.openVault();
					}
				}
				else
				{
					vaultScript.Fill = 0;
				}
			}
			else
			{
				Debug.Log("Already Looted");
			}
		}

		if (col.gameObject.tag == "atm")
		{
			if (atmScript.Looted == false)
			{

				if (EisPressed == true && Vector2.Distance(col.transform.position, transform.position) < 1f)
				{
					//if the player has the ability "Faster Unlock", the openTimer will increase faster
					if (FU == 1)
					{
						openTimer += 2.0f;
					}
					else
					{
						openTimer++;
					}

					atmScript.Fill = openTimer / atmScript.openTime;
					if (openTimer >= atmScript.openTime)
					{
						atmScript.openATM();
					}
				}
				else
				{
					atmScript.Fill = 0;
				}
			}
			else
			{
				Debug.Log("Already Looted");
			}
		}

		if (col.gameObject.tag == "Alarm")
		{
			getRayCast(col.transform.position, transform.position);

		}

		if (col.gameObject.tag == "AlarmHandle")
		{
			if (alarmHandle.Deactivated == false && alarmHandle.On == false)
			{
				if (EisPressed == true && Vector2.Distance(col.transform.position, transform.position) < 1f)
				{
					openTimer++;
					alarmHandle.Fill = openTimer / alarmHandle.turnOffTime;
					if (openTimer >= alarmHandle.turnOffTime)
					{
						alarmHandle.alarmOff();
					}
				}
				else
				{
					alarmHandle.Fill = 0;
				}
			}
			else
			{
				//Debug.Log("Already off");
			}
		}
	}

	public static bool GetPath(NavMeshPath path, Vector3 fromPos, Vector3 toPos, int passableMask)
	{
		path.ClearCorners();

		if (NavMesh.CalculatePath(fromPos, toPos, passableMask, path) == false)
			return false;

		return true;
	}

	public static float GetPathLength(NavMeshPath path)
	{
		float lng = 0.0f;
		
		if ((path.status != NavMeshPathStatus.PathInvalid))
		{
			for (int i = 1; i < path.corners.Length; ++i)
			{
				lng += Vector3.Distance(path.corners[i - 1], path.corners[i]);
			}
		}

		return lng;
	}

	void getRayCast(Vector2 x, Vector2 y)
	{
		Vector2 direction = x - y;
		RaycastHit2D hit = Physics2D.Raycast(y, direction.normalized, 4f);
		//Debug.DrawRay(transform.position, col.transform.position, Color.red, 1.5f);
		if (hit.collider != null && hit.collider.tag == "Alarm")
		{
			alarmScript.On = true;
		}
	}
}
