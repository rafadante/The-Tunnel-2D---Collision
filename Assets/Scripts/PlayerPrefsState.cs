using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class PlayerPrefsState : MonoBehaviour {

	public TextMeshProUGUI user;
	string teste;
	int cont, verifica;
	bool check;

	public void Save () 
	{
		PlayerPrefs.SetString("User", user.text.ToString());

		while(!check)
		{
			if(PlayerPrefs.HasKey("User" + cont))
				cont++;
			else
				check=true;
		}
	
		PlayerPrefs.SetInt("Numero", cont);

		for(int i =0; i<cont; i++)
		{
			if(PlayerPrefs.GetString("User" + i)==user.text.ToString())
				verifica=-100;
			else
				verifica++;
		}

		if(verifica==cont)
			PlayerPrefs.SetString("User" + cont, user.text.ToString());
	}

	public void DelPrefs()
	{
		PlayerPrefs.DeleteAll();
	}

	public List<string> Salsvos(List<string> lista)
	{
		if(PlayerPrefs.HasKey("User" + 0))
		{
			for(int i=0; i<PlayerPrefs.GetInt("Numero")+1; i++)
				lista.Add(PlayerPrefs.GetString("User" + i));
		}
		return lista;
	}

	public string Load(string user_name)
	{
		user_name = PlayerPrefs.GetString("User");
		return user_name;
	}
}