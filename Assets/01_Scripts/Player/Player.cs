using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform PlayerPos;
    public Transform EnemyPos;
    public SpriteRenderer image;

    public float playerDamage = 100;
    public float playerAttackSpeed = 1;
    public float playerMoveSpeed;

    private void FixedUpdate()
    {
        PlayerPos = gameObject.transform;
    }
}
