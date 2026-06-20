using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour {

    private Image imageComp;
    public float speed = 0.0f;

    void Start () {
        imageComp = GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
    }

    void Update()
    {
        if (imageComp.fillAmount != 1f)
        {
            imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
        }
        else
        {
            imageComp.fillAmount = 0.0f;
        }
    }
}
