using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCharacter : Character{

    //referencia do animator
    Animator ani;

    // Use this for initialization
    void Start(){
        ani = GetComponent<Animator>();
    }

    //Update é chamado uma vez por frame, logo não tem um tempo regular
    void Update(){
        lossHpWithTime();
        //animação de morte
        playDead();
        //animação de pulo
        isJumping();
        anima();
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

    void lossHpWithTime(){
        heath = heath - Time.time;
        //Debug.Log(hp);        
    }

    void anima(){
        //muda animação de movimento
        ani.SetFloat("Speed", Mathf.Abs(move));
        //muda animação de pulo
        ani.SetBool("Ground", grounded);
        ani.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        //anima a morte
        ani.SetBool("Dead", isDead);
    }

}
