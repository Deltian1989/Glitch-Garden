using UnityEngine;

public class Lizard : Attacker
{
    CapsuleCollider2D lizardCollider;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    // Start is called before the first frame update
    void Start()
    {
        lizardCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();


    }

    private void OnDestroy()
    {
        var levelController = FindObjectOfType<LevelController>();

        if (levelController)
            levelController.AttackerKilled();
    }

    public void SetWalkSpeed(float speed)
    {
        lizardCollider.enabled = true;

        if (!inFrontOfObstacle)
            walkSpeed =speed;
    }
}
