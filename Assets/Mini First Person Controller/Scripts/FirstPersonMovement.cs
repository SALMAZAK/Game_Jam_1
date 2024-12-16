using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    [Header("Climbing")]
    public float climbSpeed = 3f;
    private bool isClimbing = false;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            // حركة التسلق
            float vertical = Input.GetAxis("Vertical");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, vertical * climbSpeed, rb.linearVelocity.z);
        }
        else
        {
            // الحركة العادية
            IsRunning = canRun && Input.GetKey(runningKey);
            float targetSpeed = IsRunning ? runSpeed : speed;
            Vector2 targetVelocity = new Vector2(
                Input.GetAxis("Horizontal") * targetSpeed,
                Input.GetAxis("Vertical") * targetSpeed
            );

            rb.linearVelocity = transform.rotation * new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.y);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // التحقق من دخول السلم
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.useGravity = false; // تعطيل الجاذبية أثناء التسلق
        }
    }

    void OnTriggerExit(Collider other)
    {
        // التحقق من مغادرة السلم
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.useGravity = true; // إعادة الجاذبية
        }
    }

    public bool IsClimbing
    {
        get { return isClimbing; }
    }
}

