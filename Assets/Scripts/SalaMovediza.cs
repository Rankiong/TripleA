using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaMovediza : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("EliminacionDeBaldosas");
    }

    public void Comprobador()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine("EliminacionDeBaldosas");
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            GameObject[] goes = GameObject.FindGameObjectsWithTag("BaldosasPinchos");
            Debug.Log(goes.Length);
            for (int i = 0; i < 128; i++)
            {
                goes[i].SetActive(true);
            }
        }
    }

    IEnumerator EliminacionDeBaldosas()
    {
        for (int i = 0; i < 128; i++)
        {
            GameObject[] goes = GameObject.FindGameObjectsWithTag("BaldosasPinchos");
            goes[Random.Range(0, goes.Length)].SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Update()
    {
        Comprobador();
    }
}
