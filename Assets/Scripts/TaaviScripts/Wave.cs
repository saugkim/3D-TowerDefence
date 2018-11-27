using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
	public List<Waves> waves = new List<Waves>();
	private bool WorkingWave = false;
	public void StartWave()
	{
		WorkingWave = true;
		if (waves.Count != 0) ;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!WorkingWave)
			return;
	}

	public class Waves
	{
		public float duration = 10;
		private float startWave;

		public void StartWave()
		{
			startWave = Time.time;
		}

		public bool RunWaves()
		{
			return true;
		}
	}
}
