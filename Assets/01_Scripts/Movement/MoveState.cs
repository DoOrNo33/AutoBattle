using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{
    private Vector2 moveDirection;
    public Enemy enemy;

    private float leftWall = -12f;
    private float rightWall = 13f;

    public override void Enter(EnemyMovement movement)
    {
        SetDirection();
        StartCoroutine(SetMoveTime(movement));
    }

    public override void Execute(EnemyMovement movement)
    {
        MoveEnemy(movement);
    }

    public override void Exit()
    {
    }

    private void SetDirection()
    {
        // 0은 왼쪽, 1은 오른쪽
        int direction = Random.Range(0, 2);

        if (direction == (int)Direction.left)
        {
            moveDirection = Vector2.left;

            // 적 오브젝트 좌측 바라봄
            Vector2 scale = gameObject.transform.localScale;

            // 헬스 UI는 그대로
            Vector2 healthUIScale = enemy.healthBar.transform.localScale;

            scale.x = Mathf.Abs(scale.x);
            healthUIScale.x = Mathf.Abs(healthUIScale.x);
            gameObject.transform.localScale = scale;
            enemy.healthBar.transform.localScale = healthUIScale;
        }
        else if (direction == (int)Direction.right)
        {
            moveDirection = Vector2.right;

            // 적 오브젝트 우측 바라봄
            Vector2 scale = gameObject.transform.localScale;

            // 헬스 UI는 그대로
            Vector2 healthUIScale = enemy.healthBar.transform.localScale;

            scale.x = -Mathf.Abs(scale.x);
            healthUIScale.x = -Mathf.Abs(healthUIScale.x);
            gameObject.transform.localScale = scale;
            enemy.healthBar.transform.localScale = healthUIScale;
        }
        else
        {
            Debug.Log("적 방향 오류");
        }
    }
    
    // 일정 시간 기다린 후 다음 스테이트로
    private IEnumerator SetMoveTime(EnemyMovement movement)
    {
        float time = Random.Range(0, enemy.maxMoveTime);

        yield return new WaitForSeconds(time);

        movement.SetState(movement.idleState);
    }

    private void MoveEnemy(EnemyMovement movement)
    {
        // 오른쪽 포지션 최대
        if (transform.position.x > rightWall)
        {
            // Direction이 음수일 때만 이동
            if (moveDirection.x <= 0)
            {
                transform.position += new Vector3(moveDirection.x, 0, 0) * enemy.moveSpeed * Time.deltaTime;
            }
        }
        // 왼쪽 포지션 최대
        else if (transform.position.x < leftWall)
        {
            // Direction이 양수일 때만 이동
            if (moveDirection.x >= 0)
            {
                transform.position += new Vector3(moveDirection.x, 0, 0) * enemy.moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            transform.position += new Vector3(moveDirection.x, 0, 0) * enemy.moveSpeed * Time.deltaTime;
        }
    }
}
