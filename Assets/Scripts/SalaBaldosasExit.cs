using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaBaldosasExit : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
