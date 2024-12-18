using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 15f;

    private Rigidbody rb;
    private bool isGrounded;
    private HealthManager healthManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthManager = GetComponent<HealthManager>();
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
        // الحصول على القيم من المحاور
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // اختيار السرعة بناءً على الجري أو المشي
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // تحديد الحركة بناءً على المحاور
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * currentSpeed;

        // إضافة الحركة إلى اللاعب
        Vector3 newVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        rb.linearVelocity = newVelocity;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);
        isGrounded = false;
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
        }
    }
}


