using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f; // سرعة المشي
    public float runSpeed = 9f; // سرعة الجري
    public float jumpForce = 10f; // قوة القفز
    public float climbSpeed = 3f; // سرعة التسلق

    private Rigidbody rb;
    private bool isGrounded;
    private bool isClimbing = false; // حالة التسلق

    public Transform cameraTransform; // مرجع للكاميرا لتحريك اللاعب بالنسبة لها
    private HealthManager healthManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthManager = GetComponent<HealthManager>();

        // إذا لم يتم تعيين الكاميرا في Inspector، يتم تعيينها تلقائيًا
        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
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
        velocity.y = rb.linearVelocity.y; // الحفاظ على السرعة الرأسية الحالية (الجاذبية)
        rb.linearVelocity = velocity;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // تشغيل صوت القفز
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);
        }

        isGrounded = false;
    }

    void Climb()
    {
        float vertical = Input.GetAxis("Vertical");

        // حركة تسلق عمودية فقط
        Vector3 climbVelocity = new Vector3(0, vertical * climbSpeed, 0);
        rb.linearVelocity = climbVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.useGravity = false; // تعطيل الجاذبية أثناء التسلق
            rb.linearVelocity = Vector3.zero; // إعادة تعيين السرعة
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

    void TakeDamage()
    {
        if (healthManager != null)
        {
            healthManager.TakeDamage(1);
        }

        // تشغيل صوت الضرر
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.playerDamageSound);
        }
    }
}





