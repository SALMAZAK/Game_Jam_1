using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 15f;
    public int maxHealth = 3;

    private Rigidbody rb;
    private bool isGrounded;
    private int currentHealth;

    private Animator animator; // مرجع للأنيميشن
    private HealthManager healthManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        healthManager = FindObjectOfType<HealthManager>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);
        Vector3 velocity = new Vector3(moveHorizontal, rb.linearVelocity.y, 0);
        rb.linearVelocity = velocity;

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        AudioManager.Instance.PlaySound("JumpSound");
        isGrounded = false;
        animator.SetTrigger("Jump");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            healthManager.TakeDamage();
            AudioManager.Instance.PlaySound("DamageSound");
        }
    }
}



