using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D RB;

    private float deactivateTime = 3.0f;

    public float damage;
    public float force;

    // Start is called before the first frame update
    void OnEnable()
    {
        RB = this.GetComponent<Rigidbody2D>();
        RB.AddForce(transform.up * force, ForceMode2D.Impulse);

        //deactivate after 5 seconds for testing.
        //Invoke("DeactivateBullet", deactivateTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Damage(damage);
        }
        else
        {
            DeactivateBullet();
        }
    }

    private void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }
}
