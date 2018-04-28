using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerChoice : MonoBehaviour {

	PlayerPrefsState playerPrefs;
	List<string> lista = new List<string>();
	string player;
	public AudioClip somConfirma;

	void Start () {
		playerPrefs = new PlayerPrefsState();
		lista = playerPrefs.Salsvos(lista);

		for(int i =0; i<lista.Count; i++)
		{
			player = (i+1).ToString();
			GameObject.Find(player).GetComponent<Text>().text = lista[i];
		}
	}
	
	public void Choice(int x)
	{
		GetComponent<AudioSource>().PlayOneShot(somConfirma);
		PlayerPrefs.SetInt("UserNumber", x);
		if(PlayerPrefs.HasKey("User" + x))
		{
			PlayerPrefs.SetString("User", lista[x]);
			//SaveManager._jogador = PlayerPrefs.GetString("User", lista[x]);
			SceneManager.LoadScene("Load");
		}
	}
}