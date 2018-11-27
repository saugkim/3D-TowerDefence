using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy" && GameManagement.lives > 0)
        {
            Destroy(other.gameObject);

            GameManagement.lives--;
        }
    }
    
}
