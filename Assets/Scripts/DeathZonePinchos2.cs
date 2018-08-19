using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZonePinchos2 : MonoBehaviour {

    public Vector3 posicionInicial;
    GameObject[] BaldosasEnter;
    GameObject[] BaldosasExit;

    private void Awake()
    {
        BaldosasEnter = GameObject.FindGameObjectsWithTag("BaldosasEnter");
        BaldosasExit = GameObject.FindGameObjectsWithTag("BaldosasExit");

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.position = posicionInicial;
            other.transform.rotation = Quaternion.Euler(other.transform.rotation.x, 170, other.transform.rotation.z);

            for (int i = 0; i < BaldosasEnter.Length; i++)
            {
                BaldosasEnter[i].SetActive(true);
            }

            for (int i = 0; i < BaldosasExit.Length; i++)
            {
                BaldosasExit[i].SetActive(true);
            }
        }
    }

}
