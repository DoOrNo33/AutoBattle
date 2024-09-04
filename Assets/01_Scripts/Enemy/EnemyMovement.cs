using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Enemy enemy;
    public Transform playerPos;
    [SerializeField] private Transform enemyPos;

    [Header("이동 정보")]
    public float MaxWaitTime = 1;

    [Header("FSM")]
    public BaseState currentState;
    public MoveState moveState;
    public IdleState idleState;

    private void Start()
    {
        // Idle 스테이트로 진입
        SetState(idleState);
    }

    private void FixedUpdate()
    {
        PlayerSearch();

        if (currentState != null)
        {
            currentState.Execute(this);
        }
    }

    public void SetState(BaseState state)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = state;

        currentState.Enter(this);
    }

    private void PlayerSearch()
    {
        playerPos = GameManager.Instance.player.transform;
    }

    //public void FacePlayer()
    //{
    //    if (playerPos == null) return;
    //    enemyPos = gameObject.transform;

    //    // 플레이어와 적 사이의 거리 절대값
    //    float distance = Mathf.Abs(playerPos.position.x - enemyPos.position.x);

    //    // 플레이어가 왼쪽이라면
    //    if (playerPos.position.x < enemyPos.position.x)
    //    {
    //        // 적 오브젝트 좌측 바라봄
    //        Vector2 scale = gameObject.transform.localScale;
    //        scale.x = Mathf.Abs(scale.x);
    //        gameObject.transform.localScale = scale;
    //    }
    //    // 플레이어가 오른쪽이라면
    //    else
    //    {
    //        // 플레이어 오브젝트 우측 바라봄
    //        Vector2 scale = gameObject.transform.localScale;
    //        scale.x = -Mathf.Abs(scale.x);
    //        gameObject.transform.localScale = scale;
    //    }
    //}

    //private void MoveEnemy()
    //{

    //}
}
