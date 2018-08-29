using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour {

    //velocidade maxima que o robo se move
    public float topSpeed = 10f;
    //vai dizer pra onde ele ta virado
    public bool facingRight = true;    
    //vai dizer se ta pulando
    public bool grounded = false;    
    public Transform groundCheck;
    //vai medir a distancia do pulo
    public float groundRadius = 0.2f;
    //força do pulo
    public float jumpForce = 250f;
    //vai nos dizer onde é o chão
    public LayerMask whatIsGround;
    public float move = 0;
    protected float heath = 100f;
    private bool haveIten = false;
    protected bool isDead = false;
    protected int numItens = 0;
    public int score = 0;

    // Use this for initialization
    void Start(){        
    }

    //Update é chamado uma vez por frame, logo não tem um tempo regular
    void Update(){       
        //animação de morte
        playDead();
        //animação de pulo
        isJumping();
    }
    //FixedUpfate tem um tempo regular de execução, e todos os calculos fisicos são feitos imediatamente apos ele ser chamado
    void FixedUpdate(){        
        //função que faz personagem se mover
        movement();
        //função que faz pular
        jump();             
        //chama a função pra mudar a direção
        Flip();        
    }

    protected void movement(){
        //pega o x pra fazer o movimento
        move = Input.GetAxis("Horizontal");        
        //adiciona a velocidade ao movimento
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);        
    }

    protected void jump(){
        if (grounded && Input.GetKeyDown(KeyCode.Space)){
            //adiciona força no y
            grounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    protected void isJumping(){
        //ver se ta pulando
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);       
    }  

    protected void playDead(){
        if (heath <= 0){
            isDead = true;            
            GetComponent<RobotController>().enabled = false;
        }
    }

    protected void Flip(){
        //pega o x pra fazer o movimento
        move = Input.GetAxis("Horizontal");
        //muda a corrida de lado
        if (move > 0 && !facingRight){
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale; ;
        }
        else if (move < 0 && facingRight){
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale; ;
        }        
    }
    
    protected void addIten(int added){
        numItens = numItens + added;
    }


}
