using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaPrincipioTeletransporte : MonoBehaviour {

    public delegate void _OnPrincipioTeletransporte();
    public static event _OnPrincipioTeletransporte OnPrincipioTeletransporte;

    public GameObject Coleccionable;
    public GameObject Particulas;
    public Vector3 PosicionTeletransporte;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Coleccionable.activeSelf == false)
            {
                if (OnPrincipioTeletransporte != null)
                    OnPrincipioTeletransporte();

                //other.transform.position = XXXXX
            }
        }
    }
}
