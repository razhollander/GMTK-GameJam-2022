using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : GaneEventListener
{
    // Start is called before the first frame update
    int layer;
    [SerializeField] float range;
    UnityEngine.Rendering.Universal.Light2D light;
    public Transform end_point;
    public Transform guard_body;
    public Transform start_point;
    public int move_speed;
    int initial_speed;
    Rigidbody2D rb;
    public bool returning = false;
    SpriteRenderer renderer;
    public override void OnGameEvent(GameEvent gameEvent)
    {
        move_speed = initial_speed;

        if (gameEvent == GameEvent.Alarm)
        {
            move_speed *= 2;
        }

        else if (gameEvent == GameEvent.Flood)
        {
            move_speed /= 2;
        }
    }


    void Awake()
    {
        initial_speed = move_speed;
        layer = LayerMask.GetMask("Player");
        rb = GetComponentInChildren<Rigidbody2D>();
        light = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.up, range, layer))
        {
            light.color = Color.red;
        }
        Debug.DrawRay(transform.position, Vector2.up * range, Color.red);
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    }

    void Move()
    {
        if (!returning)
        {
            Vector3 direction = end_point.position - start_point.position;

            direction = direction.normalized;

            Vector3 velocity = direction * move_speed;
            rb.AddForce(velocity, ForceMode2D.Force);
            Look(end_point);
        }

        else
        {
            Vector3 direction = start_point.position - end_point.position;

            direction = direction.normalized;

            Vector3 velocity = direction * move_speed;
            rb.AddForce(velocity, ForceMode2D.Force);
            Look(start_point);
        }
    }

    void Look(Transform pos)
    {
        Vector3 diff = pos.position - guard_body.position;
        diff.Normalize();
        if (diff.x > 0)
        {
            var prevScale = renderer.gameObject.transform.localScale;
            renderer.gameObject.transform.localScale = new Vector3(-0.1f, prevScale.y,prevScale.z);
        }

        else
        {
            var prevScale = renderer.gameObject.transform.localScale;
            renderer.gameObject.transform.localScale = new Vector3(0.1f,  prevScale.y,prevScale.z);
        }
    }

}
