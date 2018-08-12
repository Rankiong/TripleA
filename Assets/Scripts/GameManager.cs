using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Camera CamaraPlayer;
    public GameObject PanelSinMateriales;
    public LayerMask mask;
    public float RangoRaycast;
    int ContadorDeCubos = 0;
    GameObject ObjetoPerdido = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //Elimina objetos por filtro
    public void EliminarObjetos()
    {
        RaycastHit hit;

        if(Physics.Raycast(CamaraPlayer.transform.position,CamaraPlayer.transform.forward, out hit, RangoRaycast, mask))
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Destroy(hit.transform.gameObject);
                ContadorDeCubos++;
            }
        }
    }

    //Crea objetos con filtro
    public void CrearObjetos()
    {
        RaycastHit hit;

        if(Physics.Raycast(CamaraPlayer.transform.position, CamaraPlayer.transform.forward, out hit, RangoRaycast))
        {
            if(Input.GetButtonDown("Fire2"))
            {
                if(ContadorDeCubos > 0)
                {
                    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    go.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    go.AddComponent<Rigidbody>().mass = 100;
                    go.layer = 8;
                    //go.transform.position = hit.transform.position + hit.transform.forward;
                    go.transform.position = hit.point + hit.transform.forward;
                    ObjetoPerdido = go;
                    ContadorDeCubos--;
                }
                else if(ContadorDeCubos <= 0)
                {

                }
            }
        }
    }

    //Sistema de seguridad para devolver el ultimo objeto creado
    public void EliminarUltimoObjeto()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (ObjetoPerdido != null)
            {
                Destroy(ObjetoPerdido);
                ObjetoPerdido = null;
                ContadorDeCubos++;
            }
        }
    }

    //Corrutina de advertencia cuando no tienes materiales
    IEnumerator SinMateriales()
    {
        PanelSinMateriales.SetActive(true);
        yield return new WaitForSeconds(3f);
        PanelSinMateriales.SetActive(false);
    }

    private void Update()
    {
        EliminarObjetos();
        CrearObjetos();
        EliminarUltimoObjeto();
    }
}
