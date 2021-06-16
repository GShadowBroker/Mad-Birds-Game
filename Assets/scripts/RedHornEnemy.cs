using UnityEngine;

public class RedHornEnemy : MonoBehaviour
{
    public GameObject smokeEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<RedHornEnemy>() != null) return;

        if (collision.collider.GetComponent<Bird>() != null ||
            collision.contacts[0].normal.y < -0.5
        )
        {
            Destroy(gameObject);
            Instantiate(smokeEffect, transform.position, Quaternion.identity);
        }
    }
}
