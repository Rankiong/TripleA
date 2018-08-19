using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaParkourUnoTeletransporte : MonoBehaviour {

    public Vector3 PosicionTeletransporte;
    CanvasManagerInGame canvasmanageringame = CanvasManagerInGame.Instance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = PosicionTeletransporte;
            StartCoroutine("Panel");
        }
    }

    IEnumerator Panel()
    {
        canvasmanageringame.PanelUsarObjetos.SetActive(true);
        yield return new WaitForSeconds(3f);
        canvasmanageringame.PanelUsarObjetos.SetActive(false);
    }
}
