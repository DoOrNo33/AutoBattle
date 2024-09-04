using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevel;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float distanceThreshold;
    [SerializeField] private PlayerInputManager inputManager;

    private InputAction move;
    private Vector2 moveDirection;

    private float leftWallPos = -12;
    private float rightWallPos = 13;

    //private InputAction mouseLeftClick;

    void Start()
    {
        move = inputManager.Move;

        move.performed += OnMove;
        move.canceled += OnMoveCanceled;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        FaceEnemy();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveDirection = Vector2.zero;
    }

    private void MovePlayer()
    {
        if (moveDirection.x != 0)
        {
            // 오른쪽 포지션 최대
            if (player.transform.position.x > rightWallPos)
            {
                // Direction이 음수일 때만 이동
                if (moveDirection.x <= 0)
                {
                    player.transform.position += new Vector3(moveDirection.x, 0, 0) * player.playerMoveSpeed * Time.deltaTime;

                }
            }
            // 왼쪽 포지션 최대
            else if (player.transform.position.x < leftWallPos)
            {
                // Direction이 양수일 때만 이동
                if (moveDirection.x >= 0)
                {
                    player.transform.position += new Vector3(moveDirection.x, 0, 0) * player.playerMoveSpeed * Time.deltaTime;
                }
            }
            else
            {
                player.transform.position += new Vector3(moveDirection.x, 0, 0) * player.playerMoveSpeed * Time.deltaTime;
            }
        }
    }

    public void FaceEnemy()
    {
        if (player.PlayerPos == null) return;
        if (player.EnemyPos == null) return;

        // 캐싱
        Transform pPos = player.PlayerPos;
        Transform ePos = player.EnemyPos;

        // 플레이어와 적 사이의 거리 절대값
        float distance = Mathf.Abs(pPos.position.x - ePos.position.x);

        // 플레이어가 왼쪽이라면
        if (pPos.position.x < ePos.position.x)
        {
            // 플레이어 오브젝트 우측 바라보게
            Vector2 scale = player.transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            player.transform.localScale = scale;
        }
        // 플레이어가 오른쪽이라면
        else
        {
            // 플레이어 오브젝트 좌측 바라보게
            Vector2 scale = player.transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            player.transform.localScale = scale;

            // 플레이어와 적의 거리가 너무 멀다면 다가감
            if (distance > distanceThreshold)
            {
                //player.transform.position += Vector3.left * player.playerMoveSpeed * Time.deltaTime;
            }
        }
    }
}
