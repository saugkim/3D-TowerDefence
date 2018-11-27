using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKim : MonoBehaviour
{
    float movementSpeed;
    public float startSpeed = 10f;

    Vector3 originPosition;

    public float health = 100;
    public int rewardGold = 250;

    Vector3 targetPoint;
    
    int passPointIndex;

    public GameObject spawner1;
    public GameObject spawner2;

    public List<NavPath> pathFinder;

    int tempIndex =0;


	void Start ()
    {
        spawner1 = GameObject.FindGameObjectWithTag("sp1");
        spawner2 = GameObject.FindGameObjectWithTag("sp2");
        originPosition = transform.position;

        passPointIndex = 1;
        movementSpeed = startSpeed;
     
        if(originPosition == spawner1.transform.position)
        {
            tempIndex = pathFinder[0].index;    
            targetPoint = pathFinder[0].positions[0];   
        }

        else //if(spawner == spawner2)
        {
            tempIndex = pathFinder[1].index;
            targetPoint = pathFinder[1].positions[0];
        }
    }
	
    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameManagement.currentGold += rewardGold;
    }

	void Update () 
    {
        Vector3 directionToMove = targetPoint - transform.position;

        transform.Translate(directionToMove.normalized * movementSpeed * Time.deltaTime, Space.World);
        Quaternion rot = Quaternion.LookRotation(directionToMove);
        transform.rotation = rot;

        if (Vector3.Distance(transform.position, targetPoint) <= 0.2f)
        {
            GetNextTargetPoint(tempIndex);
        }

        movementSpeed = startSpeed;
	}

    private void GetNextTargetPoint(int index)
    {
        if(passPointIndex >= pathFinder[index].positions.Length)
        {
            ReachTheTarget();
            return;
        }
       
        targetPoint = pathFinder[index].positions[passPointIndex];
        passPointIndex++;
    }

    private void ReachTheTarget()
    {
        GameManagement.lives--;
        Destroy(gameObject);
    }

    public void SlowDown(float factor)
    {
        movementSpeed = startSpeed * factor;
    }
}
