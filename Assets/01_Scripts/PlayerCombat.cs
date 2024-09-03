using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // 플레이어 위치
    [SerializeField] private Transform playerPos;
    // 공격 위치용 수정값
    [SerializeField] private Vector3 AdjustPos = new Vector3(3f, 0f, 0f);
    // 공격 인식 범위
    [SerializeField] private Vector3 attackRange;
    // 공격 속도
    [SerializeField] private float attackSpeed;

    [SerializeField] private LayerMask enemyLayer;

    private void Start()
    {

    }

    private void OnDrawGizmos()
    {
        // Gizmos 색상 설정
        Gizmos.color = Color.red;

        // OverlapBox의 크기와 위치를 시각적으로 표시
        Gizmos.DrawWireCube(playerPos.position + AdjustPos, attackRange * 2);
    }

    // 플레이어 공격
    private IEnumerator PlayerAttack()
    {
        Collider[] hits = Physics.OverlapBox(playerPos.position + AdjustPos, attackRange, Quaternion.identity, enemyLayer);

        yield return new WaitForSeconds(attackSpeed);
    }
}
