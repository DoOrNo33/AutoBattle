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
}
