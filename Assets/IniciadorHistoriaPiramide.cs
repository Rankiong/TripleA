using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciadorHistoriaPiramide : MonoBehaviour {

    CanvasManagerInGame canvasmanageringame = CanvasManagerInGame.Instance;

    bool comprobador = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && comprobador == false)
        {
            StartCoroutine("Historia");
        }
    }

    IEnumerator Historia()
    {
        comprobador = true;
        canvasmanageringame.Panel4.SetActive(true);
        yield return new WaitForSeconds(2f);
        canvasmanageringame.Panel4.SetActive(false);
    }
}
