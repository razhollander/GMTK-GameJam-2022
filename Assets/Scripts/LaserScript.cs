using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : GaneEventListener
{
    [SerializeField] LineRenderer lr;
    [SerializeField] Transform laserHead;

    public Transform startPos;
    Vector2 dir = Vector2.left;
    public float range;
    private int playerLayer;
    private int enviormentLayer;
    private int laserLayer;
    private bool _isElectricityOn = true;
    void Awake()
    {
        playerLayer = LayerMask.GetMask("Player");
        enviormentLayer=LayerMask.GetMask("enviorment collider");
        laserLayer=LayerMask.GetMask("Laser");
    }

    public override void OnGameEvent(GameEvent gameEvent)
    {
        if (gameEvent == GameEvent.Electricity)
        {
            _isElectricityOn = false;
        }
        else
        {
            _isElectricityOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isElectricityOn)
        {
            ShootLaser();
        }
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
    }

    void Draw2DRay(float distance)
    {
        lr.SetPosition(0, Vector2.zero);
        lr.SetPosition(1, distance*Vector2.left);
    }
}
