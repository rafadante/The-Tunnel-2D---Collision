using UnityEngine;

public class InsigniaUnlock : MonoBehaviour {

	private int insiginia;
	public GameObject barreira;


	void Update () {
		var objects = GameObject.FindGameObjectsWithTag("insignia");//identifica os objetos com a tag insignia
		insiginia = objects.Length;//retorna a quantidade presente na cena

		if(insiginia==0)
		{
			barreira.SetActive(false);
		}
	}
}
