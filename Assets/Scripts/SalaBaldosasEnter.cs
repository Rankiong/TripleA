using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaBaldosasEnter : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
