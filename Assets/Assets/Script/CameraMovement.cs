using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float speed = 5f;

	public float MIN_X = -3.56f;

	// Start is called before the first frame update
	public float MAX_X = 4.15f;
	public float MAX_Y = 1.3f;
	public float MIN_Y=-1.43f;
	public float MIN_Z = -23.6f;
	public float MAX_Z = -23.6f;

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
		}
		transform.position = new Vector3(
		  Mathf.Clamp(transform.position.x, MIN_X, MAX_X),
		  Mathf.Clamp(transform.position.y, MIN_Y, MAX_Y),
		  Mathf.Clamp(transform.position.z, MIN_Z, MAX_Z));
	}
}
