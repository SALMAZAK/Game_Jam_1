using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float walkSpeed = 5f; // سرعة المشي العادية
    public float runSpeed = 9f; // سرعة الجري
    public float climbSpeed = 3f; // سرعة التسلق

    [Header("Controls")]
    public KeyCode runningKey = KeyCode.LeftShift; // مفتاح الجري

    private Rigidbody rb;
    private bool isClimbing = false; // حالة التسلق

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // تثبيت دوران المجسم
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            HandleClimbing(); // حركة التسلق
        }
        else
        {
            HandleMovement(); // حركة المشي والجري
        }
    }

    void HandleMovement()
    {
        // التحقق من الجري
        bool isRunning = Input.GetKey(runningKey);
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // إدخال الحركة
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // حساب السرعة
        Vector3 moveDirection = transform.forward * moveVertical + transform.right * moveHorizontal;
        Vector3 targetVelocity = moveDirection.normalized * currentSpeed;

        // الحفاظ على الجاذبية الطبيعية
        targetVelocity.y = rb.linearVelocity.y;

        // تطبيق الحركة
        rb.linearVelocity = targetVelocity;
    }

    void HandleClimbing()
    {
        float vertical = Input.GetAxis("Vertical");

        // حركة تسلق عمودية فقط
        rb.linearVelocity = new Vector3(0, vertical * climbSpeed, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.useGravity = false; // تعطيل الجاذبية أثناء التسلق
            rb.linearVelocity = Vector3.zero; // إعادة السرعة للصفر
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.useGravity = true; // إعادة تفعيل الجاذبية
        }
    }
}

