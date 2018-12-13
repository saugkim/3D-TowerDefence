using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider HealthFiller;

    float currentHealth;
    [SerializeField]
    float maxHealth;
   
    [SerializeField]
    int rewardGold;

    Image image;
   
    [SerializeField]
    GameObject imageObject;

    public bool isDead;

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;

        image = imageObject.GetComponent<Image>();
        image.color = new Color(0, 1f, 0.06f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        HealthBarUpdate();
    }

    private void HealthBarUpdate()
    {
        HealthFiller.maxValue = maxHealth;
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
            isDead = true;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        GameManagement.currentGold += rewardGold;
    }
}
