using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaMove : MonoBehaviour
{
    public float speed;
    public CheckGround ground;

    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = ground.IsGround();

        float xSpeed = 0.0f;
        float horizotalKey = Input.GetAxis("Horizontal");

        if (0 < horizotalKey)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if (horizotalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }
}
