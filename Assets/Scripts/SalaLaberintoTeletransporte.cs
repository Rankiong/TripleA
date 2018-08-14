using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaLaberintoTeletransporte : MonoBehaviour {

    public Vector3 PosicionTeletransporte;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = PosicionTeletransporte;
        }
    }
}
