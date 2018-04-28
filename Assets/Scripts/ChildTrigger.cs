using UnityEngine;
using UnityEngine.SceneManagement;
/*Classe que detecta quando o ativador entra em contato com uma cAIXA */
public class ChildTrigger : MonoBehaviour {
	//Classe que gerencia o estado das portas de acordo com os ativadores
	ParentTriger ativador;
	bool verifica; 

	void Start()
	{
		if(SceneManager.GetActiveScene().name!="stage_11")
		{
			ativador = GameObject.Find("Ativadores").GetComponent<ParentTriger>();
		}
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if(!verifica)
		{
			if(other.gameObject.tag == "Box")
			{
				other.gameObject.tag = "side_box";
				//ativador fuca verde
				GetComponent<SpriteRenderer>().color = new Color(0,255,0);
				//verifica qtd de ativadores acionados e portas ativadas
				if(SceneManager.GetActiveScene().name!="stage_11")
				{
					ativador.ButtonAtivated();
				}
				//fixa porta na posição do ativador
				other.gameObject.transform.position = new Vector2(this.transform.position.x, other.gameObject.transform.position.y);
				other.gameObject.transform.parent = this.transform;
				other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
				verifica = true;
	
				if(this.name=="ativador_wheel_1")
					GameObject.Find("Portais").SendMessage("DesbloqueiaPortal1");
				else if(this.name=="ativador_wheel_2")
					GameObject.Find("Portais").SendMessage("DesbloqueiaPortal2");
				else if(this.name=="ativador_wheel_3")
					GameObject.Find("Portais").SendMessage("DesbloqueiaPortal3");
				else if(this.name=="ativador_wheel_4")
					GameObject.Find("Portais").SendMessage("DesbloqueiaPortal4");
			}
		}
	}
}