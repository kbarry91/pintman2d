using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controller for enemy health
/// </summary>
public class EnemyHealthController : MonoBehaviour
{

    public int enemyHealth;
    public GameObject killEffect;
    public int killPoints;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If enemys health is 0 
        if (enemyHealth <= 0)
        {
            // Instantiate particle effect
            Instantiate(killEffect, transform.position, transform.rotation);

            // add points to score
            ScoreManager.AddPoints(killPoints);

            // Destroy object
            Destroy(gameObject);
        }
    }

    // Decrease enemies health
    public void DecreaseHealth(int damage)
    {
        enemyHealth -= damage;
    }
}
