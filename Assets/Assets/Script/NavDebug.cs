using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavDebug : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] private NavMeshAgent agentDebug;
	private LineRenderer lineRenderer;

	void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		
	}

	// Update is called once per frame
	void Update()
	{
		if (agentDebug.hasPath)
		{
			lineRenderer.positionCount = agentDebug.path.corners.Length;
			lineRenderer.SetPositions(agentDebug.path.corners);
			lineRenderer.enabled = true;
		}
		else
		{
			lineRenderer.enabled = false;
		}
	}
}
