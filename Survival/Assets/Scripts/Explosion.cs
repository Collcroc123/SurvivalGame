using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    CameraShake target;
    public float damage = 100f;
    public float delay = 1f;
    public float range = 45;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);

        GetComponent<ParticleSystem>().Play();

        float distance = Mathf.Clamp01(Vector3.Distance(transform.position, target.transform.position) / range);

        float stress = (1 - Mathf.Pow(distance, 2)) * 0.6f;

        target.InduceStress(stress);
    }
}
