using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotController : Character
{

	//referencia do animator
	Animator ani;
	public float hpLostForSec = 1;
	public float timeOfStay = 1;
	private bool staying = false;
	private bool hasCollide = false;

	// Use this for initialization
	void Start()
	{
		ani = GetComponent<Animator>();
	}

	//Update é chamado uma vez por frame, logo não tem um tempo regular
	void Update()
	{
		//animação de morte
		playDead();
		//animação de pulo
		isJumping();
		anima();
	}
	//FixedUpfate tem um tempo regular de execução, e todos os calculos fisicos são feitos imediatamente apos ele ser chamado
	void FixedUpdate()
	{
		lossHpWithTime();

		if (staying)
		{
			noMovement();
		}
		else
		{
			//função que faz personagem se mover
			movement();
			//função que faz pular
			jump();
		}

		//chama a função pra mudar a direção
		Flip();
	}

	void lossHpWithTime()
	{
		heath -= hpLostForSec * 0.02f;

	}

	void anima()
	{
		//muda animação de movimento
		if (staying)
		{
			ani.SetFloat("Speed", 0);
		}
		else
		{
			ani.SetFloat("Speed", Mathf.Abs(move));
		}

		//muda animação de pulo
		ani.SetBool("Ground", grounded);
		ani.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
		//anima a morte
		ani.SetBool("Dead", isDead);
	}

	IEnumerator OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.CompareTag("enemy"))
		{
			if (hasCollide == false)
			{
				hasCollide = true;
				staying = true;
				yield return new WaitForSeconds(timeOfStay);
				staying = false;
				hasCollide = false;
				Debug.Log("colidiu");
			}
		}
	}

	protected void noMovement()
	{
		//tira a velocidade ao movimento		
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
	}



}
