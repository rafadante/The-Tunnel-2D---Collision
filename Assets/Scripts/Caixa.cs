using UnityEngine;
/*Classe que gerencia o comportamento das caixas quando as mesmas sofre o efeito da gravidade */
public class Caixa : MonoBehaviour {

	AjustaTela larguraTela;//utiliza essa classe para reposicionar a caixa quando a mesma sair da tela
	float _gravidade=1;//gravidade da caixa

	void Start()
	{
		larguraTela = GameObject.Find("Game").GetComponent<AjustaTela>();
	}
	
	void Update () {
		//verifica se o jogador saiu da tela e reposiciona o mesmo do outro lado
		if (this.transform.position.x > larguraTela.LarguraTela/2+0.3f)
			this.transform.position = new Vector2(-larguraTela.LarguraTela/2, this.transform.position.y);				
		else if(this.transform.position.x < -larguraTela.LarguraTela/2-0.3f)
			this.transform.position = new Vector2(larguraTela.LarguraTela/2, this.transform.position.y);
		//Box2 esta no nivel do player1 e vice e versa. _gravidade é a refrente ao jogador
		if(this.name == "Box2")
			_gravidade = GameObject.FindGameObjectWithTag("Player1").GetComponent<RobotController>().gravidade;
		else if(this.name == "Box1")
			_gravidade = GameObject.FindGameObjectWithTag("Player2").GetComponent<RobotController>().gravidade;
		//matem a gravidade da caixa a mesma de seu jogador
		if(_gravidade == -1)
			GetComponent<Rigidbody2D>().gravityScale = -1;
		else
			GetComponent<Rigidbody2D>().gravityScale = 1;		
	}
}