using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranaScript : GaneEventListener
{
    public Transform end_point;
    public Transform start_point;
    public Transform body;
    public int speed;
    Rigidbody2D rb;
    public bool returning = false;
    SpriteRenderer renderer;
    bool is_free = false;
    public float movment_interval = 3;
    Vector2 rand_dir;
    public override void OnGameEvent(GameEvent gameEvent)
    {
        is_free = false;
        if (gameEvent == GameEvent.Flood)
        {
            is_free = true;
        }
    }

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (!is_free) {
            Move();
        }
        else
        {
            MoveFreely();
        }
        
    }

    void Move()
    {
        if (!returning)
        {
            Vector3 direction = end_point.position - start_point.position;

            direction = direction.normalized;

            Vector3 velocity = direction * speed;
            rb.AddForce(velocity, ForceMode2D.Force);
            Look(end_point);
        }

        else
        {
            Vector3 direction = start_point.position - end_point.position;

            direction = direction.normalized;

            Vector3 velocity = direction * speed;
            rb.AddForce(velocity, ForceMode2D.Force);
            Look(start_point);
        }
    }

    void Look(Transform pos)
    {
        Vector3 diff = pos.position - body.position;
        diff.Normalize();
        if (diff.x > 0)
        {
            renderer.gameObject.transform.localScale = new Vector3(.1f, .1f, .1f);
        }

        else
        {
            renderer.gameObject.transform.localScale = new Vector3(-.1f, .1f, .1f);
        }
    }

    void MoveFreely()
    {
        Vector3 velocity = rand_dir * speed;
        rb.AddForce(velocity, ForceMode2D.Force);

        if (rand_dir.x > 0)
        {
            renderer.gameObject.transform.localScale = new Vector3(.1f, .1f, .1f);
        }

        else
        {
            renderer.gameObject.transform.localScale = new Vector3(-.1f, .1f, .1f);
        }

    }

    IEnumerator RandMove()
    {
        yield return new WaitForSeconds(movment_interval);
        rand_dir.x = Random.Range(0f, 1f);
        rand_dir.y = Random.Range(0f, 1f);
    }

}
