using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayaZone : MonoBehaviour
{
    public Transform mantaRaya;
    public Transform followed;
    public Transform defaultPosition;

    public float velocidad;
    public LayerMask triggerLayers;
    private bool dentro;

    private void OnTriggerEnter(Collider other)
    {
        dentro = true;
    }
    private void OnTriggerExit(Collider other)
    {
        dentro = false;
    }

    private void Update()
    {
        Vector3 target = dentro ? followed.position : defaultPosition.position;        

        Vector3 direction = target - mantaRaya.position;

        float remainDistance = direction.magnitude;

        if (remainDistance > 0F)
        {
            mantaRaya.rotation = Quaternion.LookRotation(direction);

            float distance = velocidad * Time.deltaTime;

            if (distance > remainDistance)
                mantaRaya.position = target;
            else
                mantaRaya.position += direction.normalized * distance;
        }
    }
}