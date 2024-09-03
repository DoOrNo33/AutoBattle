using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("몬스터 정보")]
    // TODO : 몬스터 데이터 CSV에서 가져오기
    [SerializeField] private string enemyName;
    [SerializeField] private string enemyGrade;
    [SerializeField] private float baseHealth;
    private float currentHealth;
    [SerializeField] private float moveSpeed;

    [SerializeField] private SpriteRenderer sprite;

    // TODO : 이벤트 구독 방식으로 변경
    [SerializeField] private EnemyHealthUI healthUI;

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
            EnemyManager.Instance.CreateEnemy();

            return;
        }

        healthUI.UpdateHealthUI(baseHealth, currentHealth);
    }

    //TODO : CSV를 이용해 한번에 세팅하면 될 듯
    public EnemyInfo GetEnemyInfo()
    {
        EnemyInfo info = new EnemyInfo();
        info.Name = enemyName;
        info.Grade = enemyGrade;
        info.Speed = moveSpeed;
        info.Health = baseHealth;

        return info;
    }

    public void InitializeData(EnemyData data)
    {
        enemyName = data.Name;
        enemyGrade = data.Grade;
        baseHealth = data.Health;
        moveSpeed = data.Speed;
        sprite.sprite = data.Sprite;

        SetEnemy();
    }

    private void SetEnemy()
    {
        currentHealth = baseHealth;
        healthUI.UpdateHealthUI(baseHealth, currentHealth);
    }
}

public struct EnemyInfo
{
    public string Name;
    public string Grade;
    public float Speed;
    public float Health;
}
