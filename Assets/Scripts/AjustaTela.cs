using UnityEngine;
/* Classe ajusta os sprites da tela para preencher diferentes resoluções de tela */
class AjustaTela : MonoBehaviour{

	private float larguraTela;
	private float alturaTela;

	public float AlturaTela
	{
		get{return Camera.main.orthographicSize * 2f; }//altura a tela do dispositivo
	}

	public float LarguraTela
	{
		get{return (this.AlturaTela/Screen.height * Screen.width);}//largura da tela do dispositivo
	}
		
	void Start () 
	{
		SpriteRenderer grafico = GetComponent<SpriteRenderer> ();
		//verifica a largura e altura da imagem de fundo
		float alturaImagem = grafico.sprite.bounds.size.y;
		float larguraImagem = grafico.sprite.bounds.size.x;
		//escala é ajusta de acordo com a resolução da tela do dispositivo
		Vector2 novaEscala = transform.localScale;
		novaEscala.y = this.AlturaTela / alturaImagem;
		novaEscala.x = this.LarguraTela / larguraImagem;
		transform.localScale = novaEscala;
	}
}