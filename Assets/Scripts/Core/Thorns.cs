using UnityEngine;

public class Thorns : MonoBehaviour
{
    [SerializeField] 
    private int damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthBarManager.Instance.Damage(damage);
        }
    }
}
