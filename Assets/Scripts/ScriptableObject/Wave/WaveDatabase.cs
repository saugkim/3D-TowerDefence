using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName ="WaveDatabase")]
public class WaveDatabase : ScriptableObject {

    public GameObject enemyPrefab;
    public int count;
    public float rate;
   // public Transform spawnPosition;

}
