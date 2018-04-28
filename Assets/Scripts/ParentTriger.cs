using UnityEngine;
using UnityEngine.SceneManagement;
/*Classe responsável pelo comportamento desativação da porta quando um 
objeto entra em contato com um dos ativadores */
public class ParentTriger : MonoBehaviour {

	public GameObject barreira1, barreira2, barreira3;//barreiras que serão desativadas
	public AudioClip somMag;//som quando caixa entra em contato com o ativador
	int cont;//variavel conta a qtd de ativadores acionados
	GameObject insignias;//retorna o gameobject que aloca todas as insignias da cena

	void Start()
	{
		insignias = GameObject.Find("Insinia");
		insignias.SetActive(false);
	}

	public void ButtonAtivated()
	{
		cont++;
		GetComponent<AudioSource>().PlayOneShot(somMag);

		if(cont == 6)
			insignias.SetActive(true);//as insignias são ostradas apenas quando todos os ativadores forem acionados
	}

	void Update()
	{
		//portas são desativadas de acordo com o estado dos ativadores
		if(SceneManager.GetActiveScene().name=="stage_14")
		{
			if(cont==4)
			{
				barreira3.gameObject.SetActive(false);
				insignias.SetActive(true);//as insignias são ostradas apenas quando todos os ativadores forem acionados
			}
		}
		else if(SceneManager.GetActiveScene().name=="stage_12")
		{
			if(cont==2)
			{
				barreira3.gameObject.SetActive(false);
				insignias.SetActive(true);//as insignias são ostradas apenas quando todos os ativadores forem acionados
			}
		}
		else
		{
			if(cont>0 && cont<3)
				barreira1.gameObject.SetActive(false);
			else if(cont>=3 && cont<6)
				barreira2.gameObject.SetActive(false);
			else if(cont==6)
				barreira3.gameObject.SetActive(false);
		}
	}
}