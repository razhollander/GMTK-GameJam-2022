using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : MonoBehaviour
{
    // Start is called before the first frame update
    int layer;
    [SerializeField] float range;
    UnityEngine.Rendering.Universal.Light2D light;
    public Transform end_point;
    public Transform guard_body;
    public int move_speed;
    Rigidbody2D rb;
    public bool returning = false;
    bool start = false;
    void Start()
    {
        layer = LayerMask.GetMask("Player");
        rb = GetComponentInChildren<Rigidbody2D>();
        light = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
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
            Vector3 direction = end_point.position - transform.position;

            direction = direction.normalized;

            Vector3 velocity = direction * move_speed;
            rb.AddForce(velocity, ForceMode2D.Force);
            Look(end_point);
        }

        else
        {
            Vector3 direction = transform.position - end_point.position;

            direction = direction.normalized;

            Vector3 velocity = direction * move_speed;
            rb.AddForce(velocity, ForceMode2D.Force);
            Look(transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        returning = false; 
    }

    void Look(Transform pos)
    {
        Vector3 diff = pos.position - guard_body.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        guard_body.rotation = Quaternion.Euler(0f, 0f, rot_z - 90f);
    }

}
