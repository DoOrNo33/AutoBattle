using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    private Transform enemyPos;
    public Enemy enemy;

    public override void Enter(EnemyMovement movement)
    {
        StartCoroutine(IdleEnemy(movement));
    }

    public override void Execute(EnemyMovement movement)
    {
        FacePlayer(movement);
    }

    public override void Exit()
    {
    }

    public IEnumerator IdleEnemy(EnemyMovement movement)
    {
        float waitTime = Random.Range(0f, movement.MaxWaitTime);

        yield return new WaitForSeconds(waitTime);

        movement.SetState(movement.moveState);
    }

    public void FacePlayer(EnemyMovement movement)
    {
        if (movement.playerPos == null) return;
        enemyPos = gameObject.transform;

        // 플레이어와 적 사이의 거리 절대값
        float distance = Mathf.Abs(movement.playerPos.position.x - enemyPos.position.x);

        // 플레이어가 왼쪽이라면
        if (movement.playerPos.position.x < enemyPos.position.x)
        {
            // 적 오브젝트 좌측 바라봄
            Vector2 scale = gameObject.transform.localScale;

            // 헬스 UI는 그대로
            Vector2 healthUIScale = enemy.healthBar.transform.localScale;

            scale.x = Mathf.Abs(scale.x);
            healthUIScale.x = Mathf.Abs(healthUIScale.x);
            gameObject.transform.localScale = scale;
            enemy.healthBar.transform.localScale = healthUIScale;
        }
        // 플레이어가 오른쪽이라면
        else
        {
            // 적 오브젝트 우측 바라봄
            Vector2 scale = gameObject.transform.localScale;

            // 헬스 UI는 그대로
            Vector2 healthUIScale = enemy.healthBar.transform.localScale;

            scale.x = -Mathf.Abs(scale.x);
            healthUIScale.x = -Mathf.Abs(healthUIScale.x);
            gameObject.transform.localScale = scale;
            enemy.healthBar.transform.localScale = healthUIScale;
        }
    }
}
