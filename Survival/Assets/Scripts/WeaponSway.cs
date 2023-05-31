using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSway : MonoBehaviour
{
    public float intensity;
    public float smooth;
    Quaternion initialRotation;
    float mouseX, mouseY;

    void Start()
    {
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        /*mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");*/

        Quaternion x = Quaternion.AngleAxis(-intensity * mouseX, Vector3.up);
        Quaternion y = Quaternion.AngleAxis(intensity * mouseY, Vector3.right);
        Quaternion targetRotation = initialRotation * x * y;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
    }

    public void OnLook(InputValue value)
    {
        mouseX = value.Get<Vector2>().x;
        mouseY = value.Get<Vector2>().y;
    }
}
