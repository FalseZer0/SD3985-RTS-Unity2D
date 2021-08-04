using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class RamosController : MonoBehaviour
{
	[SerializeField]
	int damage = 25;
	float idle;
	//
	List<GameObject> targetList;
	//
	int test = 0;
	GameObject gconObj;
	GameController gcontrol;
	//enemy shoot
	[SerializeField]
	GameObject muzzle;
	float timeBetweenAttacks = 1f;
	float t;
	public LineRenderer lineRenderer;
	public Transform firePoint;
	PlayerHealth playerHealth;
	//alarm
	[SerializeField]
	GameObject alarmobj;
	AlarmTrigger alarm;
	//spawn toggle
	bool playerSet = false;
	//UnityEngine.Random rnd;
	int randomcount;
	GameObject myTarget;
	public bool spawnToggle;
	//turn based
	float maxMoveDistance = 3f;
	public float stopDistance;
	//patrol
	[SerializeField]
	Transform[] waypoints;
	[SerializeField]
	float moveSpeed = 1f;
	int lastWayPoint;
	//int waypointIndex = 0;
	int waypointIndex = 0;
	bool end; // to check if the path is completed.
			  //chase
	[SerializeField] GameObject[] targets;
	[SerializeField]
	Transform target;
	private NavMeshAgent agent;
	public float distance;
	//Animation
	Animator animator;
	//vision not yet
	Vector2 direction;
	Vector2 start;
	bool insight;
	[SerializeField]
	LayerMask IgnoreMe;
	EnemyHealth health;
	AudioSource audioData;
	//enemy ai
	private enum States
	{
		Patrolling,
		Chase,
		Attack,
		Wrath,
		Chill,
	}
	[SerializeField]
	private States state;
	private void Awake()
	{
		gconObj = GameObject.FindGameObjectWithTag("GameController");
		gcontrol = gconObj.GetComponent<GameController>();

	}
	void Start()
	{
		
		//
		

		targetList = gcontrol.targetList;

		audioData = GetComponent<AudioSource>();
		foreach (GameObject s in targetList)
		{
			Debug.Log(s.transform.parent.name);
		}
		//spawn
		if (spawnToggle) state = States.Wrath;
		else state = States.Patrolling;
		Debug.Log(state);
		if (!spawnToggle)
		{
			stopDistance = 2f;
			transform.position = waypoints[waypointIndex].position;
			lastWayPoint = waypoints.Length - 1;
			end = false; // when it starts, it is definetely not the end of the path
		}

		//chase
		targets = GameObject.FindGameObjectsWithTag("Player");
		//necessary for normal mesh agent behavior
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
		agent.speed = 2f;
		agent.stoppingDistance = stopDistance;
		//ai
		insight = false;
		health = GetComponent<EnemyHealth>();
		//alarm
		//if disabled means not spawned
		if (!spawnToggle) alarm = alarmobj.GetComponent<AlarmTrigger>();

		//Animation
		animator = GetComponent<Animator>();

	}
	private void Chase()
	{
		//target spotted
		if (target != null)
		{
			//chase started
			agent.SetDestination(target.position);
			//Debug.Log(target.position);
			//rotate towards
			Vector3 vectorToTarget = target.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2);
			//stop when close enough
			distance = Vector3.Distance(transform.position, target.position);
			//Debug.Log(distance);
			if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
			{
				//Debug.Log(target+" "+insight);
				agent.isStopped = true;
				//if (insight) state = States.Attack;
				state = States.Attack;
			}
			else
			{
				agent.isStopped = false;
			}

		}
	}
	void Update()
	{
	
		
		if (playerHealth != null)
		{
			if (playerHealth.currentHealth <= 0)
			{
				playerSet = false;
			}
		}

		//if (insight) state = States.Chase;
		if (health.isDead == false)
		{
			switch (state)
			{
				case States.Attack:
					Attack();
					break;
				case States.Patrolling:
					Patrolling();
					break;
				case States.Chase:
					Chase();
					break;
				case States.Wrath:
					Wrath();
					break;
				case States.Chill:
					Chill();
					break;
			}
			//alarm
			if (!playerSet && !spawnToggle && alarm.On)
			{
				state = States.Wrath;
			}
		}
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

	}
	private void Chill()
	{

	}
	private void Wrath()
	{
		Debug.Log(gcontrol.realPlayerCounter);
		if (!playerSet)
		{

			while (true)
			{
				if (gcontrol.realPlayerCounter <= 0)
				{
					break;
				}
					if (gcontrol.realPlayerCounter == 1)
				{
					foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Player"))
					{
						if (fooObj.GetComponent<PlayerHealth>().currentHealth > 0)
						{
							myTarget = fooObj;
							playerHealth = myTarget.GetComponent<PlayerHealth>();
							playerSet = true;
						}
					}
					break;
				}
				randomcount = UnityEngine.Random.Range(0, targetList.Count);
				Debug.Log(randomcount);
				//Debug.Log(targetList[randomcount].transform.parent.name);
				if (targetList[randomcount].GetComponent<PlayerHealth>().currentHealth > 0)
				{
					myTarget = targetList[randomcount];
					Debug.Log(myTarget);
					playerHealth = myTarget.GetComponent<PlayerHealth>();
					playerSet = true;
					break;
				}
			}


		}
		Debug.Log(gcontrol.realPlayerCounter);	
		
		//chase
		if (myTarget != null)
		{
			//chase started
			agent.SetDestination(myTarget.transform.position);
			//rotate towards
			Vector3 vectorToTarget = myTarget.transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2);
			//stop when close enough
			distance = Vector3.Distance(transform.position, myTarget.transform.position);
			if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
			{
				//Debug.Log(target+" "+insight);
				agent.isStopped = true;
				//if (insight) state = States.Attack;
				state = States.Attack;
				Debug.Log(state);
			}
			else
			{
				agent.isStopped = false;
			}

		}

	}
	private void Attack()
	{
		if (spawnToggle)//spawned enemy
		{
			distance = Vector3.Distance(transform.position, myTarget.transform.position);//update the distance
			if (distance > agent.stoppingDistance)
			{
				state = States.Wrath;
			}
			if (myTarget != null && playerHealth.currentHealth > 0)
			{

				if (Vector2.Distance(myTarget.transform.position, transform.position) <= 3f)
				{

					Vector2 lookdir = myTarget.transform.position - transform.position;
					float distance = 5f;
					RaycastHit2D sightTest = Physics2D.Raycast(transform.position, lookdir.normalized, distance, ~IgnoreMe);
					if (sightTest.collider != null)
					{
						if (sightTest.collider.gameObject != gameObject && sightTest.collider.gameObject.tag == "Player")
						{

							lineRenderer.SetPosition(0, firePoint.position);
							lineRenderer.SetPosition(1, sightTest.point);
							t += Time.deltaTime;
							if (t >= timeBetweenAttacks)
							{
								Debug.Log("Shooting" + myTarget.transform.parent);
								if (sightTest.collider.gameObject.tag == "Player")
									StartCoroutine(Shoot());
								t = 0f;
								playerHealth.TakeDamage(damage);//timer
								if (playerHealth.currentHealth <= 0)
								{
									playerSet = false;
									myTarget = null;
									state = States.Wrath;
								}

							}
						}
					}
				}
			}
		}
		else // not spawned
		{
			Debug.Log(playerSet);
			//from patrol
			if (!playerSet && target != null)
			{
				if (playerHealth.currentHealth > 0)
				{
					Debug.Log("Shooting" + target.transform.parent);
					if (Vector2.Distance(target.transform.position, transform.position) <= 3f)
					{
						Vector2 lookdir = target.transform.position - transform.position;
						float distance = 5f;
						RaycastHit2D sightTest = Physics2D.Raycast(transform.position, lookdir.normalized, distance, ~IgnoreMe);
						if (sightTest.collider != null)
						{
							if (sightTest.collider.gameObject != gameObject && sightTest.collider.gameObject.tag == "Player")
							{

								lineRenderer.SetPosition(0, firePoint.position);
								lineRenderer.SetPosition(1, sightTest.point);
								t += Time.deltaTime;
								if (t >= timeBetweenAttacks)
								{

									if (sightTest.collider.gameObject.tag == "Player")
										StartCoroutine(Shoot());
									t = 0f;
									playerHealth.TakeDamage(damage);//timer
									if (playerHealth.currentHealth <= 0)
									{
										playerSet = false;
										state = States.Wrath;
									}

								}
							}
						}
					}
					distance = Vector3.Distance(transform.position, target.position);//update the distance
					if (distance > agent.stoppingDistance)
					{
						state = States.Chase;
					}
				}

			}
			else
			{
				//alarm->wrath->attack
				Debug.Log("lublu katu zaichekovu ");
				distance = Vector3.Distance(transform.position, myTarget.transform.position);//update the distance
				if (distance > agent.stoppingDistance)
				{
					state = States.Wrath;
				}
				if (myTarget != null && playerHealth.currentHealth > 0)
				{

					if (Vector2.Distance(myTarget.transform.position, transform.position) <= 3f)
					{

						Vector2 lookdir = myTarget.transform.position - transform.position;
						float distance = 5f;
						RaycastHit2D sightTest = Physics2D.Raycast(transform.position, lookdir.normalized, distance, ~IgnoreMe);
						if (sightTest.collider != null)
						{
							if (sightTest.collider.gameObject != gameObject && sightTest.collider.gameObject.tag == "Player")
							{

								lineRenderer.SetPosition(0, firePoint.position);
								lineRenderer.SetPosition(1, sightTest.point);
								t += Time.deltaTime;
								if (t >= timeBetweenAttacks)
								{
									Debug.Log("Shooting" + myTarget.transform.parent);
									if (sightTest.collider.gameObject.tag == "Player")
										StartCoroutine(Shoot());
									t = 0f;
									playerHealth.TakeDamage(10);//timer
									if (playerHealth.currentHealth <= 0)
									{
										playerSet = false;
										state = States.Wrath;
									}

								}
							}
						}
					}
				}
			}


		}


	}

		IEnumerator Shoot()
		{
			muzzle.SetActive(true);
			audioData.Play(0);
			lineRenderer.enabled = true;
			//wait 1 frame		
			//make it dependable on the gun type in future
			yield return new WaitForSeconds(0.05f);
			muzzle.SetActive(false);
			lineRenderer.enabled = false;
		}


		void OnTriggerStay2D(Collider2D collision)
		{
			if (health.isDead == false)
			{//player enters the area of sight
				if (collision.gameObject.tag == "Player" && !playerSet)
				{
					//precompute our ray settings
					start = transform.position;
					direction = collision.gameObject.transform.position - transform.position;
					float distance = 10f;
					//draw the ray in the editor
					Debug.DrawRay(start, direction, Color.red, 1);
					//do the ray test
					RaycastHit2D sightTest = Physics2D.Raycast(start, direction.normalized, distance, ~IgnoreMe);
					//Debug.Log(sightTest.collider.gameObject.transform.position + " me " + transform.position + " him " + collision.gameObject.transform.position);
					//Check if ray cast actually hit smth
					if (sightTest.collider != null)
					{
						//Debug.Log(sightTest.collider);

						//if player was hit
						if (sightTest.collider.gameObject != gameObject && sightTest.collider.gameObject.tag == "Player")
						{

							//Debug.Log(sightTest.collider);
							//the chase hasnt started already
							if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
							{
								target = collision.gameObject.transform;
								playerHealth = target.GetComponent<PlayerHealth>();
								state = States.Chase;
								//insight = true;
							}
						}

					}

				}
				else if(collision.gameObject.tag == "Player" && playerSet)
				{
				//if he wrath someone but on the way sees closer target
					myTarget = collision.gameObject;
					state = States.Wrath;
				}
			}
		}

		void Patrolling()
		{

			// end = false -> it is going to the bigger way points
			// end = true -> it is going backward
			if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.1 && end == false) // if the distance between the player and the waypoint is less than 0.1, go to the next waypoint
			{
				if (waypointIndex == lastWayPoint)
				{
					waypointIndex--;
					end = true;
				}
				else
				{
					waypointIndex++;
				}

			}

			if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.1 && end == true) // if the distance between the player and the waypoint is less than 0.1, go to the next waypoint
			{

				if (waypointIndex == 0)
				{
					waypointIndex++;
					end = false;
				}
				else
				{
					waypointIndex--;
				}
			}

			transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
			Vector3 vectorToTarget = waypoints[waypointIndex].transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2);
		}
}