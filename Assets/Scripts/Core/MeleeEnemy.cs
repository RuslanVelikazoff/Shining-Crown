using System.Collections;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField] 
    private int damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AttackCO());
            AudioManager.Instance.Play("Hit");
            HealthBarManager.Instance.Damage(damage);
        }
    }

    private IEnumerator AttackCO()
    {
        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(1f);
        
        animator.SetBool("Attack", false);
    }
}
