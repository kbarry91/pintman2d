using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{

    public int damage;
    public float bounce;
    private Rigidbody2D rigid2D;

    // Use this for initialization
    void Start()
    {
        // Get rigid body of player
        rigid2D = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealthController>().DecreaseHealth(damage);
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, bounce);
        }
    }
}
