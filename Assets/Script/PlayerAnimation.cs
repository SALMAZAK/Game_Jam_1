using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); // الحصول على الـ Animator
    }

    void Update()
    {
        // تشغيل حالة القفز عند الضغط على Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        }

        // عند الهبوط أو إنهاء القفز
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Jump", false);
        }

       
        // التحكم في السرعة (مثال على المشي والجري)
        float speed = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(speed));
    }
}