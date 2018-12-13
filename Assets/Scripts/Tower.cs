using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Transform target;
    EnemyKim targetEnemy;

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float attackRange = 15f;
    [SerializeField]
    float fireRate = 1f;
    float fireCountDown = 0f;

    [SerializeField]
    float rotationSpeed = 10f;
    [SerializeField]
    Transform partToRotate;
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    bool useSlower = false;
    [SerializeField]
    float slowAttackRange = 0;
    [SerializeField]
    float slowFactor = 0.5f;
    [SerializeField]
    float circleThickness = 0.1f;
    [SerializeField]
    GameObject drawCirclePoint;    
    
  
	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        drawCirclePoint.DrawCircle(slowAttackRange, circleThickness);
    }

	void Update ()
    {
        if (target == null)
        {            
            return;
        }

        LookOnTarget();
        
        if(useSlower)
        {
            SlowRangeAttack();
        }

        else
        {
            if (fireCountDown <= 0f)
            {
                ShootAttack();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;
        }
    }

    private void LookOnTarget()
    {
        Vector3 directionToLook = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(directionToLook);

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void SlowRangeAttack()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, slowAttackRange);

        foreach (var item in colliders)
        {
            if (item.tag == "Enemy")
            {
                item.transform.parent.GetComponent<EnemyKim>().SlowDown(slowFactor);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.transform.parent.GetComponent<EnemyMovement>().SlowDown(slowFactor);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.parent.GetComponent<EnemyMovement>().SlowDown(1);
        }
    }

    private void ShootAttack()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.FindTarget(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null  && shortestDistance <= attackRange)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyKim>();
        }
        else
        {
            target = null;
        }
    }
}
