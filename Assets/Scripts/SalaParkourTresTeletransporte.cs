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
                other.transform.rotation = Quaternion.Euler(other.transform.rotation.x, 170, other.transform.rotation.z);
            }
        }
    }

    private void Update()
    {
        if (Coleccionable.activeSelf == false)
        {
            Particulas.Play();
        }
    }
}
