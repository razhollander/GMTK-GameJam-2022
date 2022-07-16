using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    LineRenderer lr;
    public Transform startPos;
    public Transform room;
    Vector2 dir = Vector2.left;
    public float range;
    private int layer;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        layer = LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        if ( Physics2D.Raycast(startPos.position, dir, range, layer))
        {
            RaycastHit2D hit = Physics2D.Raycast(startPos.position, dir, range, layer);
            Draw2DRay(startPos.position, hit.point);
        }
        else
        {
            Draw2DRay(startPos.position, dir * range);
        }
    }

    void Draw2DRay(Vector2 startpos, Vector2 endpos)
    {
        lr.SetPosition(0, startpos);
        lr.SetPosition(1, endpos);
    }
}
