using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaMovediza : MonoBehaviour {

    GameObject[] goesSeguridad;
    bool ComprobadorTrampa = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ComprobadorTrampa == false)
        {
            ComprobadorTrampa = true;
            StartCoroutine("EliminacionDeBaldosas");
        }
    }

    private void Awake()
    {
        goesSeguridad = GameObject.FindGameObjectsWithTag("BaldosasPinchos");
    }

    private void OnEnable()
    {
        DeathZonePinchos.CuandoPlayerMuere += ResetBaldosas;
    }

    private void OnDisable()
    {
        DeathZonePinchos.CuandoPlayerMuere -= ResetBaldosas;
    }

    /*Comprobador del minijugo
    public void Comprobador()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine("EliminacionDeBaldosas");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            for (int i = 0; i < 128; i++)
            {
                goesSeguridad[i].SetActive(true);
            }
        }
    }*/

    //Corrutina de eliminacion de baldosas
    IEnumerator EliminacionDeBaldosas()
    {
        for (int i = 0; i < 128; i++)
        {
            GameObject[] goes = GameObject.FindGameObjectsWithTag("BaldosasPinchos");
            goes[Random.Range(0, goes.Length)].SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
    }
    //Funcion que resetea el minijuego
    public void ResetBaldosas()
    {
        StopCoroutine("EliminacionDeBaldosas");
        ComprobadorTrampa = false;
        for (int i = 0; i < 128; i++)
        {
            goesSeguridad[i].SetActive(true);
        }
    }
}
