using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;        // اللاعب الذي تتبعه الكاميرا
    public Vector3 offset;          // المسافة بين الكاميرا واللاعب
    public float rotationSpeed = 100f;  // سرعة دوران الكاميرا

    private float yaw = 0f;         // الدوران حول المحور Y (يسار ويمين)
    private float pitch = 0f;       // الدوران حول المحور X (أعلى وأسفل)

    void LateUpdate()
    {
        // استقبل إدخال حركة الماوس
        yaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -35f, 60f); // قيد الحركة العمودية

        // تدوير الكاميرا حول اللاعب
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 position = player.position - (rotation * offset);

        // تطبيق موقع الكاميرا وتدويرها
        transform.position = position;
        transform.LookAt(player.position);
    }
}