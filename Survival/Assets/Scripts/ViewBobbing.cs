using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ViewBobbing : MonoBehaviour
{
    public float intensityX, intensityY;
    public float speed;

    PlayerHands hands;
    Vector3 offset;
    Vector2 movement;
    float sinTime;
    bool isSprinting;

    void Start()
    {
        hands = GetComponent<PlayerHands>();
        offset = hands.offset;
    }

    void Update()
    {
        Vector3 input = new Vector3(movement.x, 0f, movement.y);

        if (input.magnitude > 0f)
        {
            if (isSprinting) sinTime += Time.deltaTime * (speed + 3);
            else sinTime += Time.deltaTime * speed;
        }
        else sinTime = 0f;

        float sinY = -Mathf.Abs(intensityY * Mathf.Sin(sinTime));
        Vector3 sinX = hands.transform.right * intensityY * Mathf.Cos(sinTime) * intensityX;

        hands.offset = new Vector3(offset.x, offset.y + sinY, offset.z);
        hands.offset += sinX;
    }

    public void OnMove(InputValue value) => movement = value.Get<Vector2>();

    public void OnSprint(InputValue value)
    {
        if (value.Get<float>() == 1) isSprinting = true;
        else isSprinting = false;
    }
}
