using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public GameObject enemy;
	public float spawnTime = 10f;
	public Transform spawnPoints;
	[SerializeField]
	GameObject alarmObj;
	AlarmTrigger alarm;
	public int enemyCount; // count the number of spawned enemies
	public int ThisEnemyNumber; // max number of enemies

	void Start()
	{
		alarm = alarmObj.GetComponent<AlarmTrigger>();

		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	private void Update()
	{
		 
	}

	void Spawn()
	{
		if (alarm.On&&!alarm.Deactivated)
		{
			if (enemyCount == ThisEnemyNumber)
			{
				return;
			}
			enemyCount++;
			GameObject temp = Instantiate(enemy, spawnPoints.position, spawnPoints.rotation);
			RamosController control = temp.GetComponent<RamosController>();
			control.spawnToggle = true;
			Debug.Log(control.spawnToggle);
		}
	
	}
}
