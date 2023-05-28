using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    public Transform camera;
    public Vector3 offset;

    void Update()
    {
        transform.position = camera.position + offset;
        transform.rotation = camera.rotation;
    }
}
