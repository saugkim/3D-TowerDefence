using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    float startSpeed;

    NavMeshAgent agent;

    Transform target;

    [SerializeField]
    GameObject[] targetPositions;

    Vector3 originPosition;

    public GameObject spawner1;
    public GameObject spawner2;
   

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        startSpeed = agent.speed;

        spawner1 = GameObject.FindGameObjectWithTag("sp1");
        spawner2 = GameObject.FindGameObjectWithTag("sp2");
        targetPositions[0] = GameObject.FindGameObjectWithTag("target1");
        targetPositions[1] = GameObject.FindGameObjectWithTag("target2");

        originPosition = transform.position;

        if (originPosition == spawner1.transform.position)
        {
            target = targetPositions[0].transform;
        }

        else if(originPosition == spawner1.transform.position)
        {
            target = targetPositions[1].transform;
        }

        else
        {
            target = targetPositions[0].transform;   
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        agent.SetDestination(target.position);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            ReachTheTarget();
        }

    }

    private void ReachTheTarget()
    {
        GameManagement.lives--;
        Destroy(gameObject);
    }

    public void SlowDown(float factor)
    { 
        agent.speed = startSpeed * factor;  
    }

}
