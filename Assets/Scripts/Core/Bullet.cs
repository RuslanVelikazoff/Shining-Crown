using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private float speed;
    [SerializeField]
    private int damage;

    [SerializeField] 
    private Rigidbody2D rigidbody;

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.Play("Hit");
            Destroy(this.gameObject);
            HealthBarManager.Instance.Damage(damage);
        }

        if (other.CompareTag("Platform"))
        {
            Destroy(this.gameObject);
        }
    }
}
