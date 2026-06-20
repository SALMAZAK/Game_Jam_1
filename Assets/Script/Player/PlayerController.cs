using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    public float jumpForce = 10f;
    public float climbSpeed = 3f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isClimbing = false;

    public Transform cameraTransform;
    public float fallLimit = -10f;

    private HealthManager healthManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthManager = GetComponent<HealthManager>();

        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        if (transform.position.y < fallLimit)
        {
            FallDamage();
            return;
        }

        if (isClimbing)
        {
            Climb();
        }
        else
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector3 moveDirection = cameraTransform.forward * moveVertical + cameraTransform.right * moveHorizontal;
        moveDirection.y = 0f;
        moveDirection.Normalize();

        Vector3 velocity = moveDirection * currentSpeed;
        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);
        }

        isGrounded = false;
    }

    void Climb()
    {
        float vertical = Input.GetAxis("Vertical");
        Vector3 climbVelocity = new Vector3(0, vertical * climbSpeed, 0);
        rb.linearVelocity = climbVelocity;
    }

    void FallDamage()
    {
        if (healthManager != null)
        {
            healthManager.TakeDamage(1);
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.playerDamageSound);
        }

        if (GameManager.Instance != null && !GameManager.Instance.isGameOver)
        {
            GameManager.Instance.ReturnPlayerToSpawn();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

            if (healthManager != null)
            {
                healthManager.TakeDamage(1);
            }

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.playerDamageSound);
            }

            if (GameManager.Instance != null && !GameManager.Instance.isGameOver)
            {
                GameManager.Instance.ReturnPlayerToSpawn();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.useGravity = true;
        }
    }
}
