using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float attackDelay = 1f;

    private bool isAttack = false;
    
    private Animator playerAnimator;

    [SerializeField] private SpawnPlayer spawnPlayer;

    private void Start()
    {
        playerAnimator = spawnPlayer.GetPlayerAnimator();

        if (PlayerPrefs.GetInt("PurchasedSphere") == 0)
        {
            attackDelay = 1f;
        }
        else
        {
            attackDelay = .5f;
        }
    }

    private void Update()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("Attack", isAttack);
        }
    }

    public void Attack()
    {
        if (!isAttack)
        {
            StartCoroutine(AttackCO());
            
            Collider2D[] enemies = Physics2D.OverlapCircleAll(this.gameObject.transform.position,
                1f, LayerMask.GetMask("Enemy"));
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i].gameObject);
            }
        }
    }

    private IEnumerator AttackCO()
    {
        isAttack = true;

        yield return new WaitForSeconds(attackDelay);

        isAttack = false;
    }
}
