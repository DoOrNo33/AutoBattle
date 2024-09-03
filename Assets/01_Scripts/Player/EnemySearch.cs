using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    [Header("적 인식")]
    // 적 인식 포지션
    [SerializeField] private Vector3 centerPos;

    // 적 인식 범위
    [SerializeField] private Vector3 searchRange;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform enemyPos;

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
            Collider[] hits = Physics.OverlapBox(centerPos, searchRange, Quaternion.identity, enemyLayer);

            if (hits != null)
            {
                foreach (Collider hit in hits)
                {
                    // 적 위치 하나만 확정
                    enemyPos = hit.gameObject.transform;
                }
            }

            yield return null;
        }

    }
}
