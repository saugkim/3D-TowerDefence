using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float MovementSpeed = 10f;
	private float RotationSpeed = 3.0f;
	private Transform waypointer;
	
	private int waypointerindex;
	
	
	// Use this for initialization
	void Start ()
	{
		waypointer = Waypoints.waypoints[0];
	}
	
	// Update is called once per frame
	void Update () {
		//Liikkuminen
		Vector3 direction = waypointer.position - transform.position;
		transform.Translate(direction.normalized*MovementSpeed*Time.deltaTime,Space.World);
		Vector3 Rotatedirection = waypointer.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(direction);
		transform.rotation = rotation;
		
		// Seuravaan Waypointin löytäminen 
		if (Vector3.Distance(transform.position, waypointer.position) < 0.5f)
		{
			nextWaypoint();
		}
	}

	void nextWaypoint()
	{
		if (waypointerindex >= Waypoints.waypoints.Length - 1)
		{
			Destroy(gameObject);
			return;
		}
		waypointerindex++;
		waypointer = Waypoints.waypoints[waypointerindex];
	}
}
