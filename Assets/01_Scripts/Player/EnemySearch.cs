using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    [Header("적 인식")]
    // 적 인식 포지션
    [SerializeField] private Vector2 centerPos;

    // 적 인식 범위
    [SerializeField] private Vector2 searchRange;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform enemyPos;

    [SerializeField] private Player player;

    private float searchThreshold = 0.5f;
    private float searchAngle = 0f;

    private void Start()
    {
        StartCoroutine(PlayerAttack());
    }

    private void OnDrawGizmos()
    {
        // Gizmos 색상 설정
        Gizmos.color = Color.red;

        // OverlapBox의 크기와 위치를 시각적으로 표시
        Gizmos.DrawWireCube(centerPos, searchRange * 2);
    }

    // 플레이어 공격
    private IEnumerator PlayerAttack()
    {
        while(true)
        {
            // 공격 콜라이더 검출
            Collider2D[] hits = Physics2D.OverlapBoxAll(centerPos, searchRange,searchAngle, enemyLayer);

            if (hits.Length > 0)
            {
                Debug.Log("!!");

                foreach (Collider2D hit in hits)
                {
                    // 적 위치 하나만 확정
                    enemyPos = hit.gameObject.transform;

                    // 첫 번째 적만 선택
                    break;
                }
                
                player.EnemyPos = enemyPos;
            }
            else
            {
                Debug.Log("적 감지 없음");
                player.EnemyPos = null;
            }

            yield return new WaitForSeconds(searchThreshold);
        }

    }
}
