using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public float MoveDirectionX;
    [HideInInspector]
    public float MoveDirectionY;

    private Rigidbody2D rb;

    [SerializeField]
    private int Speed;

    //private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        MoveDirectionX = Input.GetAxisRaw("Horizontal");
        MoveDirectionY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(MoveDirectionX * Speed, MoveDirectionY * Speed);
    }

}
