using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentScript : MonoBehaviour
{
	[SerializeField] Transform target;

	private NavMeshAgent agent;
	public float distance;

	// Start is called before the first frame update
	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		//necessary for normal mesh agent behavior
		agent = GetComponent<NavMeshAgent>();	
		agent.updateRotation = false;
		agent.updateUpAxis = false;
		agent.speed = 2f;
	}

	// Update is called once per frame
	void Update()
	{
		
		if (target != null)
		{
			//chase mechanics
			agent.SetDestination(target.position);
			//rotate towards
			Vector3 vectorToTarget = target.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2);
			//stop when close enough
			distance = Vector3.Distance(transform.position, target.position);
			if (distance <= agent.stoppingDistance)
			{
				agent.isStopped = true;
			}
			else
			{

				agent.isStopped = false;
			}

		}

		
	}

}
