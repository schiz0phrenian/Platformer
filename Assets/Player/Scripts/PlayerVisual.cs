using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Player player;
    private Rigidbody2D rb;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        player.OnJumpEvent += JumpAnimation;
    }

    private void OnDisable()
    {
        player.OnJumpEvent -= JumpAnimation;
    }
    private void Update()
    {
        animator.SetFloat("magnitude", player.CurrentSpeed);

        if (player.CurrentSpeed > 0.01f)
        {
            spriteRenderer.flipX = player.GetComponent<Rigidbody2D>().velocity.x < 0;
        }
    }

    private void JumpAnimation()
    {
        animator.SetTrigger("isJumping");
    }

}
