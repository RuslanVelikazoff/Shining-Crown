using System.Collections;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [SerializeField] 
    private Animator animator;
    
    [Space(13)]
    
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField] 
    private float bulletLifetime = 2.5f;

    private void Start()
    {
        StartCoroutine(AttackCO());
    }

    private IEnumerator AttackCO()
    {
        animator.SetBool("Attack", true);
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1f);

        animator.SetBool("Attack", false);

        yield return new WaitForSeconds(bulletLifetime - 1f);
        
        if (bullet != null)
        {
            Destroy(bullet);
        }

        StartCoroutine(AttackCO());
    }
}
