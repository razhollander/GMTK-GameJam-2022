using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEndPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponentInParent<GuardScript>())
        {
            Debug.Log("TURN");
            GetComponentInParent<GuardScript>().returning = true;
        }
        
    }
}
