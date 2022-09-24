using System;
using UnityEngine;

public class Attacker : Entity
{
    public Defender attackedTarget;
    public Vector3 spawnOffset;

    [Range(0f, 5f)]
    public float walkSpeed = 0;
    
    [SerializeField] int damage = 150;

    protected bool inFrontOfObstacle = false;
    protected Animator animator;

    protected void Walk()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }

    public void SetIdleMode(bool value)
    {
        animator.SetBool("idle", value);

        inFrontOfObstacle = value;
        walkSpeed = 0;
    }

    public void SetAttackMode(bool value)
    {
        animator.SetBool("attack", value);

        inFrontOfObstacle = value;
        walkSpeed = value ? 0 : 2;
    }

    public bool GetInFrontOfObstacleValue()
    {
        return inFrontOfObstacle;
    }

    public void AttackTarget()
    {
        if (attackedTarget)
        {
            attackedTarget.TakeDamage(damage);
        }
    }

    protected void SetWalkSpeedField(float walkSpeedValue)
    {
        walkSpeed = walkSpeedValue;
    }
}
