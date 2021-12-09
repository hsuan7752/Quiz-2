using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rbody;

    private float waitTime = 20.0f;
    private float timer = 0.0f;

    private float inputH;
    private float inputV;
    private bool run;
    private bool jump;
    public static float moveSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            float n = Random.Range(1, 4);
            switch (n)
            {
                case 1:
                    anim.Play("WAIT01");
                    break;
                case 2:
                    anim.Play("WAIT02");
                    break;
                case 3:
                    anim.Play("WAIT03");
                    break;
                case 4:
                    anim.Play("WAIT04");
                    break;
            }

            timer = 0.0f;
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("Run", run);
        anim.SetBool("Jump", jump);
        anim.SetFloat("MoveSpeed", moveSpeed);        

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        rbody.velocity = new Vector3(moveX, 0f, moveZ);

        if (inputV != 0 || inputH != 0)
            timer = 0.0f;

        if (Input.GetKey(KeyCode.LeftShift))
            run = true;
        else
            run = false;

        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
            moveSpeed = 0.0f;
        }
        else
            jump = false;

        if (Input.GetKey(KeyCode.UpArrow))
            moveSpeed += inputV * 0.01f;

        if (Input.GetKey(KeyCode.DownArrow))
            moveSpeed += inputV * 0.01f;        

        if (inputV == 0)
            moveSpeed = 0;

        if (moveSpeed > 5.0f)
            moveSpeed = 5.0f;
        if (moveSpeed < -5.0f)
            moveSpeed = -5.0f;

        transform.position = transform.position - new Vector3(inputH * Time.deltaTime * 10f, 0.0f, inputV * Time.deltaTime * 10f);
    }
}
