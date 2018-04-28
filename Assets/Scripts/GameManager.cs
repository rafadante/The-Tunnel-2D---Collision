using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
/*Classe verifica os dados salvos do game para mostrar os niveis bloqueados e desbloqueados bem
como a qtd de estrelas coletada pelo jogador em cada nível */
public class GameManager : MonoBehaviour {

	public static GameManager instance;//instancia com a classe LoadSaveData
	int cena, ajustar, time_calc, tot_stars, tot_checks;//verifica a maior cena que o jogador alcançou no jogo
	bool verifica=false, btn;//variável que abilita o estado do botão e esconde o cadeado quando o jogador desbloquea uma fase
	public Image cadeado, star3, star2, star1, empty_stars;//imagens dinâmicas da cena que variam com o estado do jogo
	public List<Image> Level = new List<Image>();//list os niveis do jogo
	public Image[] contCad, contStar;//conta a qtd de cadeados e estrelas do joador
	public AudioClip somConfirma;
	string cena_escolhida;
	public TextMeshProUGUI time_terra, time_tunel, time_col, contagem;
	public GameObject msg_1, msg2, painel_1, painel_2;
	private PlayerSavesLoads player = new PlayerSavesLoads();

    void Awake()
	{
		contCad = new Image[Level.Count];//a qtd total de cadeados na cena
		contStar = new Image[Level.Count*3];//a qtd total de estrelas da cena

		for(int i=0; i<Level.Count; i++)
		{
			Image _cadeado = Instantiate(cadeado);
			_cadeado.transform.position = Level[i].transform.position;//posiciona o cadeado no painel de acordo com os niveis
			_cadeado.transform.SetParent(Level[i].transform, true);
			_cadeado.transform.localScale = new Vector3(1,1,1);
			contCad[i] = _cadeado;//armazena o cadeado instanciado no vetor contCad

			Image _empty_stars = Instantiate(empty_stars);
			_empty_stars.transform.position = Level[i].transform.position;
			_empty_stars.transform.SetParent(Level[i].transform, true);
			_empty_stars.transform.localScale = new Vector3(1,1,1);

			Image _star1 = Instantiate(star1);
			_star1.transform.position = Level[i].transform.position;
			//_star1.transform.SetParent(GameObject.Find("_Stars").transform, true);
			_star1.transform.SetParent(Level[i].transform, true);
			_star1.transform.localScale = new Vector3(1,1,1);

			Image _star2 = Instantiate(star2);
			_star2.transform.position = Level[i].transform.position;
			//_star2.transform.SetParent(GameObject.Find("_Stars").transform, true);
			_star2.transform.SetParent(Level[i].transform, true);
			_star2.transform.localScale = new Vector3(1,1,1);

			Image _star3 = Instantiate(star3);
			_star3.transform.position = Level[i].transform.position;
			//_star3.transform.SetParent(GameObject.Find("_Stars").transform, true);
			_star3.transform.SetParent(Level[i].transform, true);
			_star3.transform.localScale = new Vector3(1,1,1);

			contStar[i+ajustar] = _star1;//as estrelas coletadas pelo jogador em cada nivel é armazenada nos vetores abaixo
			contStar[i+1+ajustar] = _star2;//as estrelas coletadas pelo jogador em cada nivel é armazenada nos vetores abaixo
			contStar[i+2+ajustar] = _star3;//as estrelas coletadas pelo jogador em cada nivel é armazenada nos vetores abaixo
		
			ajustar += 2;
		}
		instance = this;
		
		int num = PlayerPrefs.GetInt("UserNumber")+1;
		if(!PlayerPrefs.HasKey("Level1" + num))
		{
			msg_1.SetActive(true);
		}

		player.Load();
		Checks();
	}

	void Checks()
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;

		for(int i = 1; i<21; i++)
		{
			if(PlayerPrefs.GetInt("Check" + i + player)==1)
			{
				GameObject.Find("c" + i + 1).GetComponent<Image>().enabled=true;
				tot_checks+=1;
			}
			if(PlayerPrefs.GetInt("Check" + i + player)==2)
			{
				GameObject.Find("c" + i + 1).GetComponent<Image>().enabled=true;
				GameObject.Find("c" + i + 2).GetComponent<Image>().enabled=true;
				tot_checks+=2;
			}
		}
		GameObject.Find("tot_checks").GetComponent<TextMeshProUGUI>().text = tot_checks.ToString() + " / 40";
	}

	public void LoadLastSave(int x)
	{
		int cont = Level.Count;
		cena = x;

		contCad[0].enabled=false;

		if(cena==Level.Count)
		{
			cont--;
		}
		
		for(int i=0; i<cont ; i++)
		{
			if(cena >= i+1)
				contCad[i+1].enabled = false;
		}
	}

	public void LoadLista(List<int>  lista)
	{
		ajustar=0;
		for(int i=0; i<lista.Count; i++)
		{
			if(lista[i]==1)
			{
				contStar[i+ajustar].enabled = true;
				tot_stars+=1;
			}
			else if(lista[i]==2)
			{
				contStar[i+1+ajustar].enabled = true;
				tot_stars+=2;
			}	
			else if(lista[i]==3)
			{
				contStar[i+2+ajustar].enabled = true;
				tot_stars+=3;
			}
			
			ajustar += 2;
		}
		GameObject.Find("tot_stars").GetComponent<TextMeshProUGUI>().text = tot_stars.ToString() + " / 60";
	}

	public void LoadTime(float time)
	{
		time_calc= (int) (time/60);
		time_tunel.text = time_calc.ToString() + " min";
		time_terra.text = (time_calc*120).ToString() + " days";

		if(time_calc<3.0f)
		{
			PlayerPrefs.SetInt("Ano", 10);
		}
		if(time_calc==3.0f)
		{
			msg2.SetActive(true);
			contagem.text="Collision in 9 years";
			PlayerPrefs.SetInt("Ano", 9);
		}
		else if(time_calc==6.0f)
		{
			msg2.SetActive(true);
			contagem.text="Collision in 8 years";
			PlayerPrefs.SetInt("Ano", 8);
		}
		else if(time_calc==9.0f)
		{
			msg2.SetActive(true);
			contagem.text="Collision in 7 years";
			PlayerPrefs.SetInt("Ano", 7);
		}
		else if(time_calc==12.0f)
		{
			msg2.SetActive(true);
			contagem.text="Collision in 6 years";
			PlayerPrefs.SetInt("Ano", 6);
		}
		else if(time_calc==15.0f)
		{
			msg2.SetActive(true);
			contagem.text="Collision in 5 years";
			PlayerPrefs.SetInt("Ano", 5);
		}
		else if(time_calc==18.0f)
		{
			msg2.SetActive(true);
			contagem.text="Collision in 4 years";
			PlayerPrefs.SetInt("Ano", 4);
		}
		else if(time_calc==21.0f)
		{
			msg2.SetActive(true);
			contagem.text="Collision in 3 years";
			PlayerPrefs.SetInt("Ano", 3);
		}
		else if(time_calc==24.0f)
		{
			msg2.SetActive(true);
			contagem.text="Collision in 2 years";
			PlayerPrefs.SetInt("Ano", 2);
		}
		else if(time_calc==27.0f)
		{
			msg2.SetActive(true);
			contagem.text="Collision in 1 years";
			PlayerPrefs.SetInt("Ano", 1);
		}
		else if(time_calc==30.0f)
		{
			msg2.SetActive(true);
			contagem.text="Collision in 1 day";
			PlayerPrefs.SetInt("Ano", 0);
		}

		time_col.text = (3650-(time_calc*120)) + " days / " + PlayerPrefs.GetInt("Ano") + " years";
	}

	public void BtnLoad(string _cena)
	{
		cena_escolhida = _cena; 
	}

	public void BtnIndex(int level)
    {
        if(cena >= level-2)
		{
			verifica = true;
		}
            
		if(verifica)
		{
			GetComponent<AudioSource>().PlayOneShot(somConfirma);
			verifica=false; 
			StartCoroutine(Wait()); 
			GameObject.Find("Screen").SetActive(false);
			GameObject.Find("text" + level).GetComponent<TextMeshPro>().enabled=true;
		}
    }

	IEnumerator Wait()
	{
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicClass>().StopMusic();
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(cena_escolhida);
	}

	public void RightButton()
	{
		if(!btn)
		{
			painel_1.SetActive(false);
			painel_2.SetActive(true);
			btn=true;
		}
	}

	public void LeftButton()
	{
		if(btn)
		{
			painel_1.SetActive(true);
			painel_2.SetActive(false);
			btn=false;
		}
	}
}