using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    Vector3 PlayerPos;
    
    void Update()
    {
        if (Player != null)
        {
            PlayerPos.x = Player.transform.position.x;
            PlayerPos.y = Player.transform.position.y;
            PlayerPos.z = Player.transform.position.z - 10f;
        }

        transform.position = PlayerPos;

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }
}
