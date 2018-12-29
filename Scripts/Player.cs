using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb2D;  //corpo do player
    private Animator animator;  // animaçao

    [SerializeField]
    private float velocidade = 0; // vel de movimentaçao começa com 0
    float horizontal;  //movimentação

    bool grounded = true;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    float groundRadius = 0.2f;

    public float jumpForce = 200f;
    //bool jump = false;



	void Start () {

        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	
	void FixedUpdate () {

        //verificar se o player esta em contato com o solo
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("Ground", grounded);

        //verivicar se o usuario pulou
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2D.AddForce(new Vector2(0, jumpForce));
        }

        horizontal = Input.GetAxis("Horizontal");  //movimentação esquerda e direita
   
        Movimentar(horizontal);
        
	}

    private void Movimentar(float h)
    {
        rb2D.velocity = new Vector2(h*velocidade,rb2D.velocity.y); //metodo de movimentação

        animator.SetFloat("velocidade", Mathf.Abs(h)); //animaçao sem delay
    }


    }
