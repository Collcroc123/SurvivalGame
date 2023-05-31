using UnityEngine;
using UnityEngine.InputSystem;

public class ViewBobbing : MonoBehaviour
{
    [SerializeField, Range(0, 1f)] private float intensity = 0.1f;
    [SerializeField, Range(0, 30f)] private float frequency = 14f;
    Vector3 startPos;
    Vector2 movement;
    CharacterController controller;
    float strength;
    float speed; // lets frequency change when sprinting


    void Start()
    {
        controller = GetComponentInParent<CharacterController>();
        startPos = transform.localPosition;
        speed = frequency;
        strength = intensity;
    }

    void Update()
    {
        float input = new Vector3(movement.x, 0f, movement.y).magnitude;
        if (input == 0f || !controller.isGrounded) return;
        transform.localPosition += Motion();

        if (transform.localPosition == startPos) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * 5);
    }

    private Vector3 Motion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * speed) * (strength / 100f);
        pos.x += Mathf.Cos(Time.time * speed / 2) * (strength / 100f) * 2;
        return pos;
    }

    public void OnMove(InputValue value) => movement = value.Get<Vector2>();

    public void OnSprint(InputValue value)
    {
        if (value.Get<float>() == 1)
        {
            speed = frequency + 2;
            strength = intensity + 0.1f;
        }
        else
        {
            speed = frequency;
            strength = intensity;
        }
    }
}
