using UnityEngine;

public class simplerotate : MonoBehaviour {

    private RectTransform rectComponent;
    public float rotateSpeed = 200f;
    private float currentvalue;

    void Start()
    {
        rectComponent = GetComponent<RectTransform>();
    }

    void Update()
    {
        currentvalue = currentvalue + (Time.deltaTime * rotateSpeed);
        rectComponent.transform.rotation = Quaternion.Euler(0f, 0f, -72f * (int)currentvalue);
    }
}
