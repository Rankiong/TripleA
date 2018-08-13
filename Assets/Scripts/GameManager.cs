using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Variables para la creacion de objetos
    public Camera CamaraPlayer;
    public GameObject PanelSinMateriales;
    public LayerMask CuboMask;
    public LayerMask ColeccionableMask;
    public float RangoRaycast;
    int ContadorDeCubos = 0;
    GameObject ObjetoPerdido = null;


    //Funciones relacionadas con la creacion de objetos
    public void EliminarObjetos()
    {
        RaycastHit hit;

        if(Physics.Raycast(CamaraPlayer.transform.position,CamaraPlayer.transform.forward, out hit, RangoRaycast, CuboMask))
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Destroy(hit.transform.gameObject);
                ContadorDeCubos++;
            }
        }

        if (Physics.Raycast(CamaraPlayer.transform.position, CamaraPlayer.transform.forward, out hit, RangoRaycast, ColeccionableMask))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
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
    IEnumerator SinMateriales()
    {
        PanelSinMateriales.SetActive(true);
        yield return new WaitForSeconds(3f);
        PanelSinMateriales.SetActive(false);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        EliminarObjetos();
        CrearObjetos();
        EliminarUltimoObjeto();
    }
}
