using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints2 : MonoBehaviour
{

	public static Transform[] waypoints2;

	// Use this for initialization
	void Start () {
		waypoints2=new Transform[transform.childCount];
		for (int i = 0; i < waypoints2.Length; i++)
		{
			waypoints2[i]=transform.GetChild(i);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
