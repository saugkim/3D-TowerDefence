using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Transform target;
    EnemyKim targetEnemy;

    [SerializeField]
    float bulletSpeed = 50f;
    [SerializeField]
    int damage = 50;


    public void FindTarget(Transform _target)
    {
        target = _target;
    }

	void Update ()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        MoveToTarget();
    }


    private void MoveToTarget()
    {
        Vector3 directionToTarget = target.position - transform.position;

        transform.Translate(directionToTarget.normalized * bulletSpeed * Time.deltaTime, Space.World);
        transform.LookAt(target);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
            Damage(target);   
        }
    }

  
    private void Damage(Transform _target)
    {
        targetEnemy = _target.GetComponent<EnemyKim>();

        if(targetEnemy != null)
        {
            targetEnemy.TakeDamage(damage);
        }   
    }
}
