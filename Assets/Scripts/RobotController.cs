using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using UnityEngine.SceneManagement;

public class RobotController : MonoBehaviour {

	private AudioClip som_hit, som_jump, som_gravidade, som_passou, som_shoot, som_game_over;
	public Transform groundCheck, muzle;//Verifica se o jogador está com os pés no chão
	public LayerMask whatIsGrounded;//Identifica os objetos que terão o comportamento de piso
	public GameObject msg_win;//Objetos do canvas que aparecem quando algo é conquistado
	private GameObject bullet1, bullet2, bullet_portal_1, bullet_portal_2;
	public Text text_life, count_insignia, count_time;//textos camnvas
	public TextMeshProUGUI text_painel, insiginia_tot;
	public Image star_full_1, star_full_2, star_full_3;
	int insiginia, intTime;
	public int life = 5, stars, time_portal, level, unlock;
	float topSpeed = 3f,groundRadius = 0.2f, jumpForce = 220f, Timer, floatTime;
	public float gravidade = 1, floatCount;
	bool facingRight = true, girar_check, check_box_col, checar, checar2, morreu, portal_gun, first, check, check2, lado, lado2;
	public bool ganhou = false, iniciar, dano, grounded = false;
	private Vector2 initial_position;//posição que o jogador é enviado quando colide com um inimigo ou obstaculo
	private AjustaTela larguraTela;
	private Animator anim;
	public Animation death;
	private PlayerSavesLoads player = new PlayerSavesLoads();
	private Desafios desafios = new Desafios();

	void Start()
	{
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicClass>().StopMusic();
		anim = GetComponent<Animator> ();
		anim.SetBool("death", false);
		initial_position = transform.position;//quando jogador colide com obstaculo ele volta para a posição inicial
		larguraTela = GameObject.Find("Game").GetComponent<AjustaTela>();//Retorna a largura da tela
		som_hit = Resources.Load("hit") as AudioClip;
		som_jump = Resources.Load("jump") as AudioClip;
		som_gravidade = Resources.Load("gravidade") as AudioClip;
		som_passou = Resources.Load("passou") as AudioClip;
		som_shoot = Resources.Load("shoot") as AudioClip;
		som_game_over = Resources.Load("game_over") as AudioClip;
		bullet1 = Resources.Load("Bullet1") as GameObject;
		bullet2 = Resources.Load("Bullet2") as GameObject;
		bullet_portal_1 = Resources.Load("Bullet_Portal_1") as GameObject;
		bullet_portal_2 = Resources.Load("Bullet_Portal_2") as GameObject;
    }

	public void Gravidade(float g_Inicial_PA, float g_Inicial_PB, int initial_time, float initial_float_time, bool portal_g)//Classe fases retorna para esse método o estado inicial da gravidade do jogador
	{
		if (this.name == "Robot_A" && g_Inicial_PA == -1) {Girar();}//Caso a gravidade inicial seja negativa o método girar é chamado
		if (this.name == "Robot_B" && g_Inicial_PB == -1) {Girar();}//Caso a gravidade inicial seja negativa o método girar é chamado
		Timer = initial_time;
		time_portal = initial_time;
		floatCount = initial_float_time;
		portal_gun = portal_g;
	}

	void FixedUpdate()
	{		
		if(SceneManager.GetActiveScene().name=="stage_10" && this.name=="Robot_A" && !dano)
		{
			if(!GameObject.Find("enemy_01") && !GameObject.Find("enemy_02"))
				StartCoroutine(Wait());
		}
		else if(SceneManager.GetActiveScene().name=="stage_20" && this.name=="Robot_A" && !dano)
		{
			if(!GameObject.Find("enemy_01") && !GameObject.Find("enemy_02"))
				StartCoroutine(Wait());
		}

		if(!ganhou)//Se o nivel ainda não foi concluído
		{
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGrounded); //true or false did the ground transform hit the whatisgrounded with the groundRadius
			anim.SetBool ("Ground", grounded);//tell the animator that you are grounded
			anim.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.y);//get how fast we are moving up or down from the rigidybody

			if(grounded || !check_box_col)
			{
				float move = Input.GetAxis ("Horizontal"); //get move direction
				//float move = CrossPlatformInputManager.GetAxis ("Horizontal");//para dispositivo móvel
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * topSpeed, GetComponent<Rigidbody2D> ().velocity.y);//add velocity
				anim.SetFloat ("Speed", Mathf.Abs (move));//define a velocidade de movimento do jogador
				
				if (move > 0 && !facingRight)//if we are facing another direction and not facing right
					Flip ();
				else if (move < 0 && facingRight)
					Flip ();
			}
		}
	}

	void Update()
	{
		if(SceneManager.GetActiveScene().name == "stage_7")
		{
			if(this.name=="Robot_A")
			{
				if(Input.GetKeyDown(KeyCode.Joystick1Button0))
					StopPlayer1();
				else  if (Input.GetKeyDown(KeyCode.Joystick1Button3))
					StopPlayer2();
			}	
		}

		if(SceneManager.GetActiveScene().name == "stage_8")
		{
			if(this.name=="Robot_A")
			{
				if(Input.GetKeyDown(KeyCode.Joystick1Button0))
					StopPlayer2();
			}	
		}

		if(!ganhou)//Se o nivel ainda não foi concluído
		{
			anim.SetBool("atirar", false);//executa a animação de tiro do jogador
			//verifica se o jogador saiu da tela e reposiciona o mesmo do outro lado
			if (this.transform.position.x > larguraTela.LarguraTela/2)
				this.transform.position = new Vector2(-larguraTela.LarguraTela/2, this.transform.position.y);
			else if(this.transform.position.x < -larguraTela.LarguraTela/2)
				this.transform.position = new Vector2(larguraTela.LarguraTela/2, this.transform.position.y);
			//verifica o comando de pulo do jogador
			if (grounded && Input.GetKeyDown(KeyCode.Joystick1Button1))//para pc
			//if (grounded && CrossPlatformInputManager.GetButtonDown("Jump"))//para dispositivo móvel
			{
				
					GetComponent<AudioSource>().PlayOneShot(som_jump);
					anim.SetBool ("Ground", false);//not on the ground
					GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));//add jump force o the y axis
				
			}
			else if(Input.GetKeyDown(KeyCode.Joystick1Button2))//para pc
			//else if(CrossPlatformInputManager.GetButtonDown("Shoot"))//para dispositivo móvel
			{
				if(!portal_gun)
				{
					if(this.name=="Robot_A")
					{
						Instantiate(bullet1, muzle.position, muzle.rotation);//instancia a bala no braço do jogador
					}
					else if(this.name=="Robot_B")
					{
						Instantiate(bullet2, muzle.position, muzle.rotation);//instancia a bala no braço do jogador
					}
						
					GetComponent<AudioSource>().PlayOneShot(som_shoot);
					anim.SetBool("atirar", true);//executa a animação de tiro do jogador
				}
				else
				{	
					if(first)
					{
						GameObject[] objectsp = GameObject.FindGameObjectsWithTag("portal");
						for(int i=0; i<objectsp.Length; i++)
						{
							Destroy(objectsp[i]);
						}
					}
					first=true;
					if(this.name=="Robot_A")
					{
						Instantiate(bullet_portal_1, muzle.position, muzle.rotation);//instancia a bala no braço do jogador
					}
					else if(this.name=="Robot_B")
					{
						Instantiate(bullet_portal_2, muzle.position, muzle.rotation);//instancia a bala no braço do jogador
					}
					
					GetComponent<AudioSource>().PlayOneShot(som_shoot);
					anim.SetBool("atirar", true);//executa a animação de tiro do jogador
				}
			}

			//quando as duas portas locked estiverem no layer nivel zero significa que os dois jogadores abriram as portas simultaneamente
			if(GameObject.Find("DoorLocked_A").GetComponent<Door>().acessou)
			{
				ganhou = true;//nivel foi concluidoe e funções dos métodos update e fixedupdate não são mais executadas
				anim.SetFloat ("Speed", 0);//desabilita o movimento do jogador
				StartCoroutine(Wait());//sistema de espera que é executado quando o nivel for concluído	
			}

			var objects = GameObject.FindGameObjectsWithTag("insignia");//identifica os objetos com a tag insignia
			insiginia = objects.Length;//retorna a quantidade presente na cena
			
			Timer -= Time.deltaTime;//retorna o tempo
			intTime = (int) Timer;//variavel pega somente a parte inteira
			floatTime = Timer;

			count_insignia.text = ((insiginia - 6)*-1).ToString() + "/6";//exibe o texto da contagem das insignias coletadas
			count_time.text = intTime.ToString();//exibe o texto do tempo do jogo
		}
	}

	void Flip()
	{
		facingRight = !facingRight;//saying we are facing other direction
		Vector3 theScale = transform.localScale;//get the local scale
		theScale.x *= -1;//flip scale
		transform.localScale = theScale;//apply that to the local scale
	}

	public void NivelConcluido()//método é chamado quando jogador conclui o nivel ou perde todas as vidas
	{
		GameObject.Find("Robot_A").GetComponent<RobotController>().dano=true;
		GameObject.Find("Robot_B").GetComponent<RobotController>().dano=true;
		GetComponent<SpriteRenderer>().enabled = false;//se ganhou jogador invisivel
		msg_win.SetActive(true);
		insiginia_tot.text = count_insignia.text;

		int p1Life = GameObject.FindGameObjectWithTag("Player1").GetComponent<RobotController>().life;//quantidade de vidas do jogador 1
		int p2Life = GameObject.FindGameObjectWithTag("Player2").GetComponent<RobotController>().life;//quantidade de vidas do jogador 2
		int totLife = p1Life + p2Life;//quantidade de vidas total
			
		if(insiginia == 0) //Condições verificam quantas estrelas o jogador ganhou baseado nas insignias, tempo e vida
		{
			star_full_1.enabled = true;
			stars++;
			unlock++;
		}
		if(intTime >= 0)
		{
			star_full_2.enabled = true;
			stars++;
		}
		if(totLife == 10)
		{
			star_full_3.enabled = true;
			stars++;
			unlock++;
		}
		//Quando jogador vence os dados de qtd de estrelas e nivel desbloqueado são salvos
		text_painel.text = "Level Completed";
		level = SceneManager.GetActiveScene().buildIndex;

		time_portal = (time_portal-intTime);
		floatCount = (floatCount-floatTime);
		player.Save(this);
		player.LoadPlayer(this);
		desafios.Admin(this);	
	}

	public void Girar()//Método reponsável pela mudança de escala e gravidade do jogador
	{
		GetComponent<AudioSource>().PlayOneShot(som_gravidade);
		gravidade = gravidade * -1;//muda o estado da gravidade do jagador
		this.GetComponent<Rigidbody2D> ().gravityScale = gravidade;//gravidade é invertida
		Vector3 theScale = transform.localScale;

		theScale.x *= 1;//flip scale
		theScale.y *= -1;//flip scale
		transform.localScale = theScale;//apply that to the local scale
		jumpForce *= -1;//quando jogador girar o sentido do pulo precisa ser invertido
	}

	private void OnCollisionStay2D(Collision2D other) 
	{
		if(other.gameObject.tag == "Barrel" || other.gameObject.tag == "side_box" || other.gameObject.tag=="Box" ||
		   other.gameObject.tag == "divisor" || other.gameObject.tag=="barreira_1" || other.gameObject.tag=="barreira_2"
		|| other.gameObject.tag=="barreira_3")
			check_box_col = true;
	}

	private void OnTriggerEnter2D(Collider2D other) 
	{
		if(!dano)
		{
			if((other.gameObject.tag == "obstaculo" || other.gameObject.tag == "enemy" || other.gameObject.tag == "bullet_enemy"))//se o jogador colidir com um obstáculo
			{
				GetComponent<AudioSource>().PlayOneShot(som_hit);
				transform.position = initial_position;//jogador volta para a posição inicial
				StartCoroutine(TomouDano());//faz o jogador piscar quando colidir com um obstaculo
				life--;//vida do jogador é diminuida a cada colisão
				text_life.text = life.ToString();//texto é mostrado no canvas
				
				if(life == 0) //se um dos jogadores perder toda a vida
				{
					GameObject.Find("Robot_A").GetComponent<RobotController>().anim.SetBool ("death", true);
					GameObject.Find("Robot_B").GetComponent<RobotController>().anim.SetBool ("death", true);
					StartCoroutine(WaitGameOver());
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
					GetComponent<AudioSource>().PlayOneShot(som_game_over);
					time_portal = (time_portal-intTime);
					//SaveLoadDataNew.Save(this);
				}
			}
		}
	}

	private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag == "Barrel" || other.gameObject.tag == "side_box" || other.gameObject.tag=="Box" 
		|| other.gameObject.tag == "divisor" || other.gameObject.tag=="barreira_1" || other.gameObject.tag=="barreira_2"
		|| other.gameObject.tag=="barreira_3")
			check_box_col = false;
	}

	IEnumerator TomouDano()//faz o jogador piscar quando colidir com um obstaculo
	{
		for(int i = 0; i < 5; i++)
		{
			if(!ganhou && life<1)
				GetComponent<SpriteRenderer>().enabled = false;	
				yield return new WaitForSeconds(0.05f);
				GetComponent<SpriteRenderer>().enabled = true;
				yield return new WaitForSeconds(0.05f);
		}
	}

	IEnumerator Wait()
	{
		anim.SetFloat ("Speed", 0);//define a velocidade de movimento do jogador
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().PlayOneShot(som_passou);
		GameObject.Find("Robot_A").GetComponent<RobotController>().ganhou=true;
		GameObject.Find("Robot_B").GetComponent<RobotController>().ganhou=true;
		GameObject.Find("Robot_A").GetComponent<RobotController>().dano=true;
		GameObject.Find("Robot_B").GetComponent<RobotController>().dano=true;
		GameObject.Find("Robot_A").GetComponent<SpriteRenderer>().enabled=false;
		GameObject.Find("Robot_B").GetComponent<SpriteRenderer>().enabled=false;
		GameObject.Find("Congratulations").GetComponent<TextMeshPro>().enabled=true;
		GameObject.Find("Congratulations").GetComponent<TextMeshPro>().text="Congratulations!";
		yield return new WaitForSeconds(4);
		GameObject.Find("Congratulations").GetComponent<TextMeshPro>().enabled=false;
		NivelConcluido();
		GameObject.Find("Screen").SetActive(false);
		GameObject.Find("back_win").GetComponent<SpriteRenderer>().enabled=true;
	}

	IEnumerator WaitGameOver()
	{
		anim.SetFloat ("Speed", 0);//define a velocidade de movimento do jogador
		GameObject.Find("Robot_A").GetComponent<RobotController>().ganhou=true;
		GameObject.Find("Robot_B").GetComponent<RobotController>().ganhou=true;
		GameObject.Find("Robot_A").GetComponent<RobotController>().dano=true;
		GameObject.Find("Robot_B").GetComponent<RobotController>().dano=true;
		GameObject.Find("Congratulations").GetComponent<TextMeshPro>().enabled=true;
		GameObject.Find("Congratulations").GetComponent<TextMeshPro>().text="You Lose";
		yield return new WaitForSeconds(4);
		GameObject.Find("Congratulations").GetComponent<TextMeshPro>().enabled=false;
		GameObject.Find("Screen").SetActive(false);
		GameObject.Find("back_win").GetComponent<SpriteRenderer>().enabled=true;
		msg_win.SetActive(true);
		text_painel.text = "Game Over";
	}
	
	public void StopPlayer1()
	{
		if(GameObject.Find("Robot_A").GetComponent<RobotController>().ganhou==false)
		{
			GameObject.Find("Robot_A").GetComponent<RobotController>().ganhou=true;
			GameObject.Find("btn_player_1").GetComponent<Image>().enabled=false;
			GameObject.Find("btn_player_1_green").GetComponent<Image>().enabled=true;
		}
		else
		{
			GameObject.Find("Robot_A").GetComponent<RobotController>().ganhou=false;
			GameObject.Find("btn_player_1").GetComponent<Image>().enabled=true;
			GameObject.Find("btn_player_1_green").GetComponent<Image>().enabled=false;
		}
	}

	public void StopPlayer2()
	{
		if(GameObject.Find("Robot_B").GetComponent<RobotController>().ganhou==false)
		{
			GameObject.Find("Robot_B").GetComponent<RobotController>().ganhou=true;
			GameObject.Find("btn_player_2").GetComponent<Image>().enabled=false;
			GameObject.Find("btn_player_2_green").GetComponent<Image>().enabled=true;
		}
		else
		{
			GameObject.Find("Robot_B").GetComponent<RobotController>().ganhou=false;
			GameObject.Find("btn_player_2").GetComponent<Image>().enabled=true;
			GameObject.Find("btn_player_2_green").GetComponent<Image>().enabled=false;
		}	
	}	
}