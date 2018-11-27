using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Navigation", menuName ="Navigation")]
public class NavPath : ScriptableObject
{
    public int index;
    public Vector3[] positions;
    public Vector3 spawnPoint;    
}
