using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://roystan.net/articles/camera-shake/
public class CameraShake : MonoBehaviour
{
    Vector3 maxTrans = Vector3.one;
    Vector3 maxRot = Vector3.one * 15;

    [SerializeField] float speed = 25;
    [SerializeField] float recovery = 1;
    float trauma;

    void Update()
    {
        if (trauma == 0) return;
        float shake = Mathf.Pow(trauma, 1);
        float seed = Random.value;

        transform.localPosition = new Vector3(
            maxTrans.x * (Mathf.PerlinNoise(seed, Time.time * speed) * 2 - 1),
            maxTrans.y * (Mathf.PerlinNoise(seed + 1, Time.time * speed) * 2 - 1),
            maxTrans.z * (Mathf.PerlinNoise(seed + 2, Time.time * speed) * 2 - 1)
        ) * shake;

        transform.localRotation = Quaternion.Euler(new Vector3(
            maxRot.x * (Mathf.PerlinNoise(seed + 3, Time.time * speed) * 2 - 1),
            maxRot.y * (Mathf.PerlinNoise(seed + 4, Time.time * speed) * 2 - 1),
            maxRot.z * (Mathf.PerlinNoise(seed + 5, Time.time * speed) * 2 - 1)
        ) * shake);

        trauma = Mathf.Clamp01(trauma - recovery * Time.deltaTime);
    }

    public void InduceStress(float stress)
    {
        trauma = Mathf.Clamp01(trauma + stress);
    }
}
