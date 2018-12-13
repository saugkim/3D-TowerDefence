using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKim : MonoBehaviour
{
    float movementSpeed;
    public float startSpeed = 10f;

    Vector3 originPosition;

    public float maxHealth;
    public int rewardGold = 250;

    [SerializeField]
    float offset;

    public Slider HealthFiller;

    float currentHealth;

    Image image;

    [SerializeField]
    GameObject imageObject;

    Vector3 targetPoint;
    
    int passPointIndex;

    public GameObject spawner1;
    public GameObject spawner2;

    public List<NavPath> pathFinder;

    int tempIndex =0;


	void Start ()
    {
        currentHealth = maxHealth;

        image = imageObject.GetComponent<Image>();
        image.color = new Color(0, 1f, 0.06f);

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

        HealthFiller.maxValue = maxHealth;
    }

    private void HealthBarUpdate()
    {
      
        HealthFiller.value = currentHealth;

        float health = currentHealth / maxHealth;

        if (health >= 0.25 && health < 0.60)
        {
            image.color = Color.yellow;
        }
        else if (health < 0.25)
        {
            image.color = Color.red;
        }

        if (currentHealth <= 0)
        {
            
        }
    }


    public void TakeDamage(float amount)
    {
        
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        GameManagement.currentGold += rewardGold;
    }

	void Update () 
    {
        HealthBarUpdate();
        //Debug.Log(currentHealth);
        Vector3 directionToMove = targetPoint - transform.position;

        transform.Translate(directionToMove.normalized * movementSpeed * Time.deltaTime, Space.World);
        Quaternion rot = Quaternion.LookRotation(directionToMove);
        transform.rotation = rot;

        if (Vector3.Distance(transform.position, targetPoint) <= offset)
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
