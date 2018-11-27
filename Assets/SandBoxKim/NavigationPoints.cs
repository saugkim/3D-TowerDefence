using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavigationPoints : MonoBehaviour {

    public static Transform[] navigationPoints;

	void Awake ()
    {
        navigationPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            navigationPoints[i] = transform.GetChild(i);
        }
	            	
	}
}
