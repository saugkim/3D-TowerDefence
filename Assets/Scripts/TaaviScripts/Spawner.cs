using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public List<Transform> spawnPoint = new List<Transform>();

	public List<GameObject> spawnPrefabs = new List<GameObject>();

	public void Spawn(int spawnPrefabsIndex, int spawnPointIndex)
	{
		Instantiate(spawnPrefabs[spawnPrefabsIndex], spawnPoint[spawnPointIndex].position,
			spawnPoint[spawnPointIndex].rotation);
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
