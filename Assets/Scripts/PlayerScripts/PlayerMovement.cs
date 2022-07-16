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
    [SerializeField]
    private int roll_speed;
    [SerializeField] private float roll_time;
    //private Animator animator;

    public bool rolling = false;

    private bool can_dash = true;
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
        rb.AddForce( new Vector2(MoveDirectionX * Speed, MoveDirectionY * Speed), ForceMode2D.Force);

        if (Input.GetKey(KeyCode.Space) && can_dash)
        {
            Roll();
        }
    }

    void Roll()
    {
        can_dash = false;
        rb.AddForce(new Vector2(MoveDirectionX, MoveDirectionY) * roll_speed, ForceMode2D.Impulse);
        StartCoroutine(start_dash());  
    }

    IEnumerator start_dash()
    {
        rolling = true;
        yield return new WaitForSeconds(roll_time);
        can_dash = true;
        rolling = false;
    }
}
