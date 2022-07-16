using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] LineRenderer lr;
    [SerializeField] Transform laserHead;

    public Transform startPos;
    Vector2 dir = Vector2.left;
    public float range;
    private int playerLayer;
    private int enviormentLayer;
    private int laserLayer;

    void Start()
    {
        playerLayer = LayerMask.GetMask("Player");
        enviormentLayer=LayerMask.GetMask("enviorment collider");
        laserLayer=LayerMask.GetMask("Laser");
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        dir = -laserHead.right;
        float dist=0;
        var hit = Physics2D.Raycast(startPos.position, dir, range, enviormentLayer | laserLayer);

        if (hit.collider != null)
        {
            dist = Vector3.Distance(hit.point, startPos.position);
            Draw2DRay(dist);
            
            if (hit.collider.tag == "Player")
            {
                GameManager.Instance.GameOver();
            }
        }
        //var hit = Physics2D.Raycast(startPos.position, dir, range, enviormentLayer);
        //var envCollider =
        //if (hit.collider!=null)
        //{
        //    var envCollider =
        //        dist = Vector3.Distance(hit.point, startPos.position);
        //}
        //
        //hit = Physics2D.Raycast(startPos.position, dir, range, laserLayer);
        //if(
//
        //    if (hit.collider != null)
        //    {
        //        dist = Vector3.Distance(hit.point, startPos.position);
        //        Draw2DRay(dist);
//
        //        if (hit.collider.tag == "Player")
        //        {
        //            GameManager.Instance.GameOver();
        //        }
        //    }
        //    else
        //    {
        //        dist=range;
        //    }
        //}
        //Draw2DRay(dist);
        

        //var hitPlayer = Physics2D.Raycast(startPos.position, dir, range, playerLayer);


        //if ( hitPlayer.collider!=null)
        //{
        //    var dist = Vector3.Distance(hitPlayer.point, startPos.position);
        //    Draw2DRay(dist);
        //    GameManager.Instance.GameOver();
        //}
        //else
        //{
        //    var hit = Physics2D.Raycast(startPos.position, dir, range, enviormentLayer|laserLayer);
        //    if (hit.collider!=null)
        //    {
        //        var dist = Vector3.Distance(hit.point, startPos.position);
        //        Draw2DRay(dist);
        //    }
        //    else
        //    {
        //        var dist = range;
        //        Draw2DRay(dist);
        //    }
        //}
    }

    void Draw2DRay(float distance)
    {
        lr.SetPosition(0, Vector2.zero);
        lr.SetPosition(1, distance*Vector2.left);
    }
}
