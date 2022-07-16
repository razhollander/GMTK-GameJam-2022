using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : MonoBehaviour
{
    // Start is called before the first frame update
    int layer;
    [SerializeField] float range;
    UnityEngine.Rendering.Universal.Light2D light;
    void Start()
    {
        layer = LayerMask.GetMask("Player");
        light = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, range, layer);
        if (Physics2D.Raycast(transform.position, Vector2.up, range, layer))
        {
            light.color = Color.red;
        }
        Debug.DrawRay(transform.position, Vector2.up * range, Color.red);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    }


    void move()
    {

    }

}
