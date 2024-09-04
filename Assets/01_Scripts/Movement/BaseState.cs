using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    public abstract void Enter(EnemyMovement movement);

    public abstract void Execute(EnemyMovement movement);

    public abstract void Exit();
}
