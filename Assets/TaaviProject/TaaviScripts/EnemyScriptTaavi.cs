using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScriptTaavi : MonoBehaviour
{

	public Transform EndPoint;
	public Transform healthBar;
	public Slider HealthFiller;
	public float curHealth;
	public float maxHealth;
	private bool death;

    [SerializeField]
    Image image;

    [SerializeField]
    GameObject imageObject;

	private NavMeshAgent enemy;
	// Use this for initialization
	void Start ()
	{
		enemy = this.GetComponent<NavMeshAgent>();
		curHealth = maxHealth;

        image = imageObject.GetComponent<Image>();
        image.color = new Color(0, 1f, 0.06f);	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 targetVector = EndPoint.transform.position;
		enemy.SetDestination(targetVector);
		HealthFiller.maxValue = maxHealth;
		HealthFiller.value = curHealth;

        float health = curHealth / maxHealth;

        if( health >= 0.25 && health < 0.60)
        {
            image.color = Color.yellow;
        }
        else if(health < 0.25)
        {
            image.color = Color.red;
        }

		if (curHealth <= 0)
		{
			Death();
		}
        
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			curHealth -= 10;
		}
	}

	void Death()
	{
		Destroy(gameObject);
	}
	
}
