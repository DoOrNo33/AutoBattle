using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform PlayerPos;
    public Transform EnemyPos;
    public SpriteRenderer image;

    public float playerDamage = 100;
    public float playerAttackSpeed = 1f;
    public float playerMoveSpeed;
    public float attackRange = 0.5f;

    public bool Invincible = false;

    public Animator animator;

    // 애니메이터 해쉬
    public int HitHash;

    private void Awake()
    {
        HitHash = Animator.StringToHash("Hit");
    }

    private void FixedUpdate()
    {
        PlayerPos = gameObject.transform;
    }

    public void TakeDamage()
    {
        // 무적 아니면 피격 판정
        if (!Invincible)
        {
            Invincible = true;
            animator.SetTrigger(HitHash);
        }
    }
}