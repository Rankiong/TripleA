using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaParkourTresTeletransporte : MonoBehaviour
{

    public GameObject Coleccionable;
    public ParticleSystem Particulas;
    public Vector3 PosicionTeletransporte;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Coleccionable.activeSelf == false)
            {
                other.transform.position = PosicionTeletransporte;
                Particulas.Play();
            }
        }
    }
}
