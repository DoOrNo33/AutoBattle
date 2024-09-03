using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // TODO : 몬스터 데이터 CSV에서 가져오기
    [SerializeField] private float baseHealth;
    private float currentHealth;

    [SerializeField] private float moveSpeed;

    private void Start()
    {
        currentHealth = baseHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            // UI 업데이트

            // 죽음 로직
            Destroy(gameObject);

        }
    }
}
