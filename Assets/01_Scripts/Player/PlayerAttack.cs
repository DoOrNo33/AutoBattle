using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerAnimation playerAnimation;

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(player.playerAttackInterval);
            Attack();
        }
    }

    private void Attack()
    {
        // 이미지 변경
        playerAnimation.ChangeAttackSprite();

        // 적 검출
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, player.attackRange);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                enemy.TakeDamage(player.playerDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, player.attackRange);
    }
}
