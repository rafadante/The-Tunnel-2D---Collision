using UnityEngine;
/*Classe responsável pelo comportamento da bala */
public class Bullet_Portal_1 : MonoBehaviour {

	public float bulletSpeed;//velocidade da bala
	public RobotController player;//ajusta a escala da bala de acordo com a do jogador
	public GameObject portal_1;//prefab com a animação da explosão
	AjustaTela larguraTela;
	bool verifica;

	void Start()
	{
		larguraTela = GameObject.Find("Game").GetComponent<AjustaTela>();
		player = FindObjectOfType<RobotController>();

		if(player.transform.localScale.x < 0)
		{
			bulletSpeed = -bulletSpeed;
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}
	}
	
	void Update () 
	{
		if(GameObject.Find("Robot_A").GetComponent<RobotController>().life==0 || GameObject.Find("Robot_B").GetComponent<RobotController>().life==0 )
			Destroy(this.gameObject);

		GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);
		//verifica se a bala saiu da tela e reposiciona a mesmo do outro lado
		if (this.transform.position.x > larguraTela.LarguraTela/2)
			this.transform.position = new Vector2(-larguraTela.LarguraTela/2, this.transform.position.y);
		else if(this.transform.position.x < -larguraTela.LarguraTela/2)
			this.transform.position = new Vector2(larguraTela.LarguraTela/2, this.transform.position.y);			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "side_box")
		{
			if(!verifica)
			{
				Instantiate(portal_1, this.transform.position, this.transform.rotation);//portal é instaciada no local onde ocorreu a colisão
				Destroy(gameObject);//portal é destruída
				verifica=true;
			}
		}
		else if(other.gameObject.tag == "barreira_3")
			Destroy(gameObject);
	}
}