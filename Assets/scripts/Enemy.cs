using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject smokeEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Enemy>() != null) return;

        if (collision.collider.GetComponent<Bird>() != null ||
            collision.contacts[0].normal.y < -0.5
        )
        {
            Destroy(gameObject);
            Instantiate(smokeEffect, transform.position, Quaternion.identity);
        }
    }
}
