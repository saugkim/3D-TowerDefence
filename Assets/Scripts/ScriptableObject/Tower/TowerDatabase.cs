using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu (fileName = "Tower", menuName ="Tower")]
public class TowerDatabase : ScriptableObject
{
    public GameObject towerPrefab;
    public GameObject towerUpgraded1Prefab;
    public GameObject towerUpgraded2Prefab;

    public string towerName;
    public int upgradedState;
    public int cost;
    public int upgrade1Cost;
    public int upgrade2Cost;
	
}
