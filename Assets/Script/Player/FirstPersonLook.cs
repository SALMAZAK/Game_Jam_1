using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    private Transform character; // المرجع للشخصية

    [Header("Camera Settings")]
    public float sensitivity = 2f; // حساسية الحركة
    public float smoothing = 1.5f; // نعومة الحركة

    private Vector2 velocity; // تخزين سرعة الدوران
    private Vector2 frameVelocity; // سرعة الإطار الحالي

    private Transform cameraTransform; // المرجع للكاميرا

    void Start()
    {
        // قفل مؤشر الفأرة داخل اللعبة
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // الحصول على الكاميرا المتصلة باللاعب
        cameraTransform = Camera.main.transform;

        if (character == null)
        {
            Debug.LogError("Character Transform is not assigned!");
        }
    }

    void Update()
    {
        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        // الحصول على حركة الماوس
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;

        // تحديد حدود الحركة العمودية
        velocity.y = Mathf.Clamp(velocity.y, -90f, 90f);

        // تطبيق الدوران
        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right); // حركة عمودية
        }

        if (character != null)
        {
            character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up); // حركة أفقية
        }
    }
}