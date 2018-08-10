using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kevin : MonoBehaviour {

    private void Awake()
    {
        for (int i = 0; i < int.MaxValue; i++)
        {
            float tiempo = Time.time;
            Debug.Log(tiempo);
        }
    }

    public void Tiempo()
    {
        float tempo = Time.deltaTime;
        Debug.Log(tempo);

        if (tempo <= 2)
            Debug.Log("Hola");
        if (tempo >= 3 && tempo <= 4)
            Debug.Log("Venga");
        if (tempo >= 5)
            Debug.Log("Pues ya estaria");
    }

    private void Start()
    {
        Tiempo();
    }

    private void Update()
    {
        //Debug.Log(tiempo);
    }
}
