using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantaRaya : MonoBehaviour {

    public Vector3 posicioninicial;
    public Transform jugador;
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.position = posicioninicial;
        }    
    }
}
