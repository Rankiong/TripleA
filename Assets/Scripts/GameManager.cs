using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    //FinDeJuego findejuego = FinDeJuego.findejuego;

    CanvasManagerInGame canvasmanageringame = CanvasManagerInGame.Instance;
    public Animator AnimacionCrosshair;

    //Variables para la creacion de objetos
    public GameObject Piedra;
    public Camera CamaraPlayer;
    public GameObject PanelSinMateriales;
    public LayerMask CuboMask;
    public LayerMask ColeccionableMask;
    public Color color;
    public float RangoRaycast;
    int ContadorDeCubos = 7;
    GameObject ObjetoPerdido = null;
    bool ComprobadorDeAnimaciones1 = false;
    bool ComprobadorDeAnimaciones2 = false;



    //Funciones relacionadas con la creacion de objetos
    public void EliminarObjetos()
    {
        RaycastHit hit;

        if(Physics.Raycast(CamaraPlayer.transform.position,CamaraPlayer.transform.forward, out hit, RangoRaycast, CuboMask | ColeccionableMask))
        {
            AnimacionCrosshair.Play("Static");

            if (Input.GetButtonDown("Fire1"))
            {
                if(Time.timeScale == 1)
                {
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Objetos"))
                    {
                        Destroy(hit.transform.gameObject);
                        ContadorDeCubos++;
                        if (AnimacionCrosshair.GetCurrentAnimatorStateInfo(0).IsName("Static"))
                        {
                            StartCoroutine("Animacion");
                        }
                    }
                    else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Coleccionable"))
                    {
                        hit.transform.gameObject.SetActive(false);
                        if (AnimacionCrosshair.GetCurrentAnimatorStateInfo(0).IsName("Static"))
                        {
                            StartCoroutine("Animacion");
                        }
                    }
                }
            }
        }
        else
        {
            //if (ComprobadorDeAnimaciones1)
            //{
            //    StartCoroutine("AnimacionVacia");
            //}
            if(ComprobadorDeAnimaciones1 == false)
            {
                AnimacionCrosshair.Play("None");
            }
        }

        //if (Physics.Raycast(CamaraPlayer.transform.position, CamaraPlayer.transform.forward, out hit, RangoRaycast, ColeccionableMask))
        //{
        //    AnimacionCrosshair.Play("Static");
        //    comprobador = true;

        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        if(Time.timeScale == 1)
        //        {
        //            hit.transform.gameObject.SetActive(false);
        //        }
        //    }
        //}
        //else
        //{
        //    comprobador = false;
        //}

        //if(comprobador == false)
        //{
        //    AnimacionCrosshair.Play("None");
        //}
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
                    //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    GameObject go = Instantiate(Piedra, hit.point + hit.transform.forward, Quaternion.identity);
                    go.transform.localScale = new Vector3(4, 4, 4);
                    //go.GetComponent<MeshRenderer>().material.color = color;
                    go.AddComponent<Rigidbody>().mass = 100;
                    go.layer = 8;
                    //go.transform.position = hit.transform.position + hit.transform.forward;
                    //go.transform.position = hit.point + hit.transform.forward;
                    ObjetoPerdido = go;
                    ContadorDeCubos--;
                }
                else if(ContadorDeCubos <= 0)
                {
                    StartCoroutine("SinMateriales");
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
        canvasmanageringame.PanelSinMateriales.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        canvasmanageringame.PanelSinMateriales.SetActive(true);
    }

    IEnumerator Animacion()
    {
        ComprobadorDeAnimaciones1 = true;
        AnimacionCrosshair.Play("RotacionGeneral");
        yield return new WaitForSeconds(1f);
        AnimacionCrosshair.Play("None");
        yield return new WaitForSeconds(1f);
        ComprobadorDeAnimaciones1 = false;

    }

    public void Instanciar()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(this.gameObject);
        }
    }

    private void Awake()
    {
        this.Instanciar();
        Cursor.visible = false;

    }

    private void Update()
    {
        EliminarObjetos();
        CrearObjetos();
        EliminarUltimoObjeto();

        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene(2);
        }

        //if(Input.GetKeyDown(KeyCode.V))
        //{
        //        AnimacionCrosshair.Play("RotacionGeneral 0");
        //        AnimacionCrosshair.Play("None");

        //}

        //if(Input.GetKeyDown(KeyCode.B))
        //{
        //    AnimacionCrosshair.Play("Static");
        //}
    }
}
