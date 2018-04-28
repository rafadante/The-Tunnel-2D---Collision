using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionEvents : MonoBehaviour {

	private bool state;
	private AudioClip som_win;

	private void Start() 
	{
		som_win = Resources.Load("win") as AudioClip;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "g_off" && !state)//se o jogador colidir com o ativador de gravidade
		{
			state=true;
			other.GetComponent<SpriteRenderer>().enabled = false;
			
			if(SceneManager.GetActiveScene().name!="stage_8")
				GetComponent<RobotController>().Girar();//quando a graviadade é ativada o método girar é chamado
			else 
				GameObject.Find("Robot_A").GetComponent<RobotController>().Girar();
		}
		else if(other.gameObject.tag == "insignia")//se ojogador colidir com uma insignia
		{	
			GetComponent<AudioSource>().PlayOneShot(som_win);
			Destroy(other.gameObject);//insignia é destruída
		}
		else if(other.gameObject.tag == "divisor")
			this.transform.parent = other.gameObject.transform;		
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "divisor")
			this.transform.parent = GameObject.Find("Game").transform;
		if(other.gameObject.tag == "g_off")//se o jogador sair da colisão com o ativador o mesmo volta para o estado vermelho
			other.GetComponent<SpriteRenderer>().enabled = true;
			state=false;	
	}
}