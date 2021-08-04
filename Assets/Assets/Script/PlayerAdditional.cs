using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAdditional : MonoBehaviour
{
	private NavMeshAgent agent;
	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
		agent.speed = 3.0f;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
