using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Player player;

    //private Coroutine playerAttack;

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(player.playerAttackSpeed);
            Attack();
        }
    }

    private void Attack()
    {
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
    ////// 적 검출되면 공격 시작
    ////private void OnTriggerEnter2D(Collider2D collision)
    ////{
    ////    if (collision.CompareTag("Enemy"))
    ////    {
    ////        Enemy enemy = collision.GetComponent<Enemy>();
    ////        playerAttack = StartCoroutine(AttackEnemy(enemy));

    ////    }
    ////}

    ////// 적 없어지면 공격 중단
    ////private void OnTriggerExit2D(Collider2D collision)
    ////{
    ////    if (collision.CompareTag("Enemy"))
    ////    {
    ////        StopCoroutine(playerAttack);
    ////    }
    ////}

    //// 적 공격
    //private IEnumerator AttackEnemy(Enemy enemy)
    //{
    //    while (true)
    //    {
    //        enemy.TakeDamage(player.playerDamage);

    //        yield return new WaitForSeconds(player.playerAttackSpeed);
    //    }
    //}

    //// TODO: 플레이어 조작으로 빠르게 collider 범위 안팍을 오갈 때 처리
}
