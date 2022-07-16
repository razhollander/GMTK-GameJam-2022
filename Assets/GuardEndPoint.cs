using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEndPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<GuardScript>().returning = true;
    }
}
