using UnityEngine;
using UnityEngine.UI;

public class loadingtext : MonoBehaviour {

    private Image imageComp;
    public float speed = 200f;
    public Text text;
    public Text textNormal;

    void Start () {
        imageComp = GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
    }

    void Update () {
        if (imageComp.fillAmount != 1f)
        {
            imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            int a = (int)(imageComp.fillAmount * 100);
            if (a > 0 && a <= 33)
            {
                textNormal.text = "Loading...";
            }
            else if (a > 33 && a <= 67)
            {
                textNormal.text = "Downloading...";
            }
            else if (a > 67 && a <= 100)
            {
                textNormal.text = "Please wait...";
            }
            text.text = a + "%";
        }
        else
        {
            imageComp.fillAmount = 0.0f;
            text.text = "0%";
        }
    }
}
