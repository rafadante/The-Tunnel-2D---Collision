using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSavesLoads : MonoBehaviour 
{
	private int nivel, player, cont=1;
	private bool a, repetir;
	private List<int> lista = new List<int>();
	private List<string> lista_strings = new List<string>();
	private List<float> time = new List<float>();
	private float time_total, recorde;
	private string jogador;
	public void Save(RobotController robot)
	{
		nivel = robot.level-1;
		player = PlayerPrefs.GetInt("UserNumber")+1;

		if(PlayerPrefs.HasKey("First" + player + nivel))
			PlayerPrefs.SetFloat("TimeTotal" + nivel + player, PlayerPrefs.GetFloat("TimeTotal" + nivel + player) + robot.floatCount);

		if(!PlayerPrefs.HasKey("First" + player + nivel))
		{
			PlayerPrefs.SetString("Player" + player, PlayerPrefs.GetString("User"));
			PlayerPrefs.SetInt("Level" + nivel + player, nivel);
			PlayerPrefs.SetInt("Stars" + nivel + player, robot.stars);
			PlayerPrefs.SetInt("Check" + player, nivel);
			PlayerPrefs.SetFloat("Time" + nivel + player, robot.floatCount);
			PlayerPrefs.SetInt("First" + player + nivel, 1);
			PlayerPrefs.SetFloat("TimeTotal" + nivel + player, robot.floatCount);
		}
		else if(robot.unlock==2 && robot.floatCount < PlayerPrefs.GetFloat("Time" + nivel + player))
		{
			PlayerPrefs.SetString("Player" + player, PlayerPrefs.GetString("User"));
			PlayerPrefs.SetInt("Level" + nivel + player, nivel);
			PlayerPrefs.SetInt("Stars" + nivel + player, robot.stars);
			PlayerPrefs.SetFloat("Time" + nivel + player, robot.floatCount);

			if(robot.level > PlayerPrefs.GetInt("Check" + player))
			{
				PlayerPrefs.SetInt("Check" + player, nivel);
			}
		}
	}

	public void Load()
	{
		player = PlayerPrefs.GetInt("UserNumber")+1;

		for(int i = 0; i<PlayerPrefs.GetInt("Check" + player); i++)
		{
			lista.Add(PlayerPrefs.GetInt("Stars" + (i+1) + player));
			time_total = time_total + PlayerPrefs.GetFloat("TimeTotal" + (i+1) + player);
		}

		GameManager.instance.LoadLastSave(PlayerPrefs.GetInt("Check" + player));
		GameManager.instance.LoadTime(time_total);
		GameManager.instance.LoadLista(lista);
	}

	public void LoadPlayer(RobotController robot)
	{
		if(robot.unlock==2)
		{
			PlayerPrefsState playerPrefs = new PlayerPrefsState();
			lista_strings = playerPrefs.Salsvos(lista_strings);

			while(!repetir)
			{
				if(PlayerPrefs.HasKey("Player" + cont))
				{
					cont++;
				}
				else
				{
					repetir = true;
				}	
			}

			for(int i = 0; i<cont; i++)
			{
				if(PlayerPrefs.HasKey("Level" + (robot.level-1) + (i+1)))
				{
					time.Add(PlayerPrefs.GetFloat("Time" + (robot.level-1) + (i+1)));
				}
			}

			if(time.Count>1)
			{
				for(int i=0; i<time.Count; i++)
				{
					if(!a)
					{
						recorde=time[i];
						jogador = lista_strings[i];
						a=true;
					}

					if(recorde>time[i+1])
					{
						recorde=time[i+1];
						jogador = lista_strings[i+1];
					}

					if((i+2)>=time.Count)
					{
						break;
					}
				}

				GameObject.Find("melhor_tempo").GetComponent<TextMeshProUGUI>().text = recorde.ToString() + " s";
				GameObject.Find("player_rec").GetComponent<TextMeshProUGUI>().text = jogador;
				GameObject.Find("meu_tempo").GetComponent<TextMeshProUGUI>().text = time[time.Count-1].ToString() + " s";
			}
			else
			{
				GameObject.Find("melhor_tempo").GetComponent<TextMeshProUGUI>().text = time[0] + " s";
				GameObject.Find("player_rec").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("User");
				GameObject.Find("meu_tempo").GetComponent<TextMeshProUGUI>().text = robot.floatCount + " s";
			}
		}
	}
}