using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] LineRenderer lr;
    public Transform startPos;
    Vector2 dir = Vector2.left;
    public float range;
    private int playerLayer;
    private int enviormentLayer;

    void Start()
    {
        playerLayer = LayerMask.GetMask("Player");
        enviormentLayer=LayerMask.GetMask("enviorment collider");
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        if ( Physics2D.Raycast(startPos.position, dir, range, playerLayer))
        {
            RaycastHit2D hit = Physics2D.Raycast(startPos.position, dir, range, playerLayer);
            Draw2DRay(startPos.position, hit.point);
        }
        else
        {
            if (Physics2D.Raycast(startPos.position, dir, range, enviormentLayer))
            {
                RaycastHit2D hit = Physics2D.Raycast(startPos.position, dir, range, playerLayer);
                Draw2DRay(startPos.position, hit.point);
            }
            else
            {
                Draw2DRay(startPos.position, dir * range);
            }
        }
    }

    void Draw2DRay(Vector2 startpos, Vector2 endpos)
    {
        lr.SetPosition(0, startpos);
        lr.SetPosition(1, endpos);
    }
}
