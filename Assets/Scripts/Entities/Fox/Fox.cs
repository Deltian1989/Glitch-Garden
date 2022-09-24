using System.Collections.Generic;
using UnityEngine;

public class Fox : Attacker
{
    [Range(0f, 5f)]
    [SerializeField] float runSpeed = 2.3f;
    [Range(0f, 5f)]
    [SerializeField] float crouchSpeed = 1;
    [Range(0f, 5f)]
    [SerializeField] float jumpSpeed = 2.3f;

    [SerializeField] List<Defender> sniffedDefnders;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if (!animator.GetBool("attack"))
         {
            if (sniffedDefnders.Count > 0 && walkSpeed != runSpeed && walkSpeed != jumpSpeed && walkSpeed != 0)
            {
                animator.SetBool("hasEnemiesSniffed", true);
                walkSpeed = runSpeed;
            }
            else if (sniffedDefnders.Count <= 0 && walkSpeed != crouchSpeed && walkSpeed != jumpSpeed && walkSpeed != 0)
            {
                animator.SetBool("hasEnemiesSniffed", false);
                walkSpeed = crouchSpeed;
            }

            Walk();
         }
        
    }

    private void OnDestroy()
    {
        var levelController = FindObjectOfType<LevelController>();

        if (levelController)
            levelController.AttackerKilled();
    }

    public void SetJumpTrigger()
    {
        walkSpeed = jumpSpeed;

        animator.SetTrigger("canJump");
        
    }

    public void AddSniffedDefender(Defender defender)
    {
        sniffedDefnders.Add(defender);
    }

    public void RemoveSniffedDefender(Defender defender)
    {
        sniffedDefnders.Remove(defender);
    }

    public void SetWalkSpeedToZeroWhileFalling()
    {
        walkSpeed = 0;
    }

    public void SetWalkSpeedAfterJumping()
    {
        
        animator.SetTrigger("canJump");

        if (animator.GetBool("hasEnemiesSniffed"))
        {
            walkSpeed = runSpeed;
            
        }
        else
        {
            walkSpeed = crouchSpeed;
        }

        
    }
}
