using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemywave : MonoBehaviour
{

	public Transform enemy1;
	public Transform enemy2;
	public float SpawnCount = 15f;

	public float WaveCount = 10f;

	private int EnemyNum=0;

	public Transform whereSpawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (WaveCount <= 0)
		{
			StartCoroutine(EnemyWaveCount());
			EnemyWaveCount();
			WaveCount = SpawnCount;
		}

		WaveCount -= Time.deltaTime;
	}

	IEnumerator EnemyWaveCount()
	{
		EnemyNum++;
		for (int i = 0; i < EnemyNum; i++)
		{
			Enemy1Spawner();
			yield return new WaitForSeconds(10f);
			Enemy2Spawner();
			yield return new WaitForSeconds(20f);
			
		}
		
		
	}

	void Enemy1Spawner()
	{
		Instantiate(enemy1,whereSpawn.position,whereSpawn.rotation);
		
	}

	void Enemy2Spawner()
	{
		Instantiate(enemy2, whereSpawn.position, whereSpawn.rotation);
	}

}
