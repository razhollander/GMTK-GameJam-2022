using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private int speed;
    [SerializeField]
    private int max_dis;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < max_dis)
        {
            Vector3 direction = player.position - transform.position;

            direction = direction.normalized;

            Vector3 velocity = direction * speed;
            rb.AddForce(velocity, ForceMode2D.Force);

        }
    }
}
