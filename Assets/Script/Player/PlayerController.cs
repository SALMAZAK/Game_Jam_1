using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f; // سرعة المشي
    public float runSpeed = 9f; // سرعة الجري
    public float jumpForce = 10f; // قوة القفز

    [Header("Controls")]
    public KeyCode runningKey = KeyCode.LeftShift; // مفتاح الجري

    private Rigidbody rb;
    private bool isGrounded = true; // التحقق من كون اللاعب على الأرض

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // تثبيت دوران المجسم
    }

    void FixedUpdate()
    {
        HandleMovement(); // حركة المشي والجري
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump(); // تنفيذ القفز
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

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // تحديث حالة الأرض
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // اللاعب عاد إلى الأرض
        }
    }
}




