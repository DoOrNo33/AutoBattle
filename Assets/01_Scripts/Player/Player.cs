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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerPos = gameObject.transform;
    }
}
