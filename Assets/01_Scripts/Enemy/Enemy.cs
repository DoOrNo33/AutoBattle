using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // TODO : 몬스터 데이터 CSV에서 가져오기
    [SerializeField] private float baseHealth;
    private float currentHealth;

    [SerializeField] private float moveSpeed;

    // TODO : 이벤트 구독 방식으로 변경
    [SerializeField] private EnemyHealthUI healthUI;

    private void Start()
    {
        currentHealth = baseHealth;
        healthUI.UpdateHealthUI(baseHealth, currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            // UI 업데이트
            healthUI.UpdateHealthUI(baseHealth, currentHealth);

            // 죽음 로직
            Destroy(gameObject);

            return;
        }

        healthUI.UpdateHealthUI(baseHealth, currentHealth);
    }
}
