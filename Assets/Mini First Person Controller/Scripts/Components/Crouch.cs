using UnityEngine;

public class Crouch : MonoBehaviour
{
    public KeyCode key = KeyCode.LeftControl;

    [Header("Slow Movement")]
    public FirstPersonMovement movement;
    public float movementSpeed = 2;

    [Header("Low Head")]
    public Transform headToLower;
    public float crouchYHeadPosition = 1;
    private float? defaultHeadYLocalPosition;

    [Header("Collider Adjustment")]
    public CapsuleCollider colliderToLower;
    private float? defaultColliderHeight;

    public bool IsCrouched { get; private set; }
    public event System.Action CrouchStart, CrouchEnd;

    void Reset()
    {
        movement = GetComponentInParent<FirstPersonMovement>();
        headToLower = GetComponentInChildren<Camera>().transform;
        colliderToLower = GetComponentInChildren<CapsuleCollider>();
    }

    void LateUpdate()
    {
        if (movement != null && movement.IsClimbing)
        {
            // منع الانحناء أثناء التسلق
            return;
        }

        if (Input.GetKey(key))
        {
            // خفض الكاميرا
            if (headToLower)
            {
                if (!defaultHeadYLocalPosition.HasValue)
                {
                    defaultHeadYLocalPosition = headToLower.localPosition.y;
                }
                headToLower.localPosition = new Vector3(headToLower.localPosition.x, crouchYHeadPosition, headToLower.localPosition.z);
            }

            // تعديل الكوليدر
            if (colliderToLower)
            {
                if (!defaultColliderHeight.HasValue)
                {
                    defaultColliderHeight = colliderToLower.height;
                }
                float loweringAmount = defaultHeadYLocalPosition.Value - crouchYHeadPosition;
                colliderToLower.height = Mathf.Max(defaultColliderHeight.Value - loweringAmount, 0);
                colliderToLower.center = Vector3.up * colliderToLower.height * 0.5f;
            }

            // حالة الانحناء
            if (!IsCrouched)
            {
                IsCrouched = true;
                movement.speed = movementSpeed;
                CrouchStart?.Invoke();
            }
        }
        else
        {
            if (IsCrouched)
            {
                // إعادة الكاميرا
                if (headToLower)
                {
                    headToLower.localPosition = new Vector3(headToLower.localPosition.x, defaultHeadYLocalPosition.Value, headToLower.localPosition.z);
                }

                // إعادة الكوليدر
                if (colliderToLower)
                {
                    colliderToLower.height = defaultColliderHeight.Value;
                    colliderToLower.center = Vector3.up * colliderToLower.height * 0.5f;
                }

                // إعادة السرعة
                IsCrouched = false;
                movement.speed = movement.runSpeed; // إعادة السرعة الأصلية
                CrouchEnd?.Invoke();
            }
        }
    }
}
