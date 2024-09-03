using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float distanceThreshold;

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
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

            // 플레이어와 적의 거리가 너무 멀다면 다가감
            if (distance > distanceThreshold)
            {
                player.transform.position += Vector3.right * player.playerMoveSpeed * Time.deltaTime;
            }
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
                player.transform.position += Vector3.left * player.playerMoveSpeed * Time.deltaTime;
            }
        }
    }
}
