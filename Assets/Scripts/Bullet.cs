using UnityEngine;
/*Classe responsável pelo comportamento da bala */
public class Bullet : MonoBehaviour {

	public float bulletSpeed;//velocidade da bala
	public float player1, player2;//ajusta a escala da bala de acordo com a do jogador
	public GameObject explosion;//prefab com a animação da explosão
	AjustaTela larguraTela;

	void Start()
	{
		larguraTela = GameObject.Find("Game").GetComponent<AjustaTela>();
		player1 = GameObject.Find("Robot_A").transform.localScale.x;
		player2 = GameObject.Find("Robot_B").transform.localScale.x;

		if(this.name=="BulletEnemy1(Clone)")
		{
			bulletSpeed = -7;
		}
		else if(this.name=="BulletEnemy2(Clone)")
		{
			bulletSpeed = 7;
		}
		else if(this.name=="Bullet1(Clone)" && player1<0)
		{
			bulletSpeed = -bulletSpeed;
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}
		else if(this.name=="Bullet2(Clone)" && player2<0)
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
		if(other.gameObject.tag == "insignia" || other.gameObject.tag == "Door" || other.gameObject.tag == "Untagged")
		{

		}
		else
		{
			//se colidir com um barril o mesmo é explodido
			if(other.gameObject.tag == "Barrel" || other.gameObject.tag == "enemy")	
				Destroy(other.gameObject);

			if(this.name!="BulletEnemy1(Clone)" || this.name!="BulletEnemy2(Clone)")
			{
				//explosão é instaciada no local onde ocorreu a colisão
				Instantiate(explosion, this.transform.position, this.transform.rotation);
				Destroy(gameObject);//bala é destruída
			}
		}
	}
}