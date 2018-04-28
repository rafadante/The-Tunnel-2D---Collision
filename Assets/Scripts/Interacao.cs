using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
/*Classe responsável por carregar cenas e e sair do jogo */
public class Interacao : MonoBehaviour {
	
	public AudioClip somConfirma;
	public GameObject panel, msg_info, msg_1, msg_2;
	private bool verifica;
	public int level;

	public void Carregarena(string cena)
	{
		if(cena=="Load")
		{
			GameObject.FindGameObjectWithTag("music").GetComponent<MusicClass>().PlayMusic();
		}
		else if(cena=="menu")
		{
			Destroy(GameObject.FindGameObjectWithTag("music"));
		}
		
		GetComponent<AudioSource>().PlayOneShot(somConfirma);
		StartCoroutine(Wait(cena));
	}

	public void Panel()
	{
		panel.SetActive(true);
	}

	public void HideMsg()
	{
		GetComponent<AudioSource>().PlayOneShot(somConfirma);
		msg_1.SetActive(false);
	}

	public void HideMsg2()
	{
		GetComponent<AudioSource>().PlayOneShot(somConfirma);
		msg_2.SetActive(false);
	}

	public void Msg_Info()
	{
		if(!verifica)
		{
			msg_info.SetActive(true);
			GameObject.Find("Robot_A").GetComponent<RobotController>().ganhou=true;
			GameObject.Find("Robot_B").GetComponent<RobotController>().ganhou=true;
			verifica=true;
		}
		else if(verifica)
		{
			msg_info.SetActive(false);
			GameObject.Find("Robot_A").GetComponent<RobotController>().ganhou=false;
			GameObject.Find("Robot_B").GetComponent<RobotController>().ganhou=false;
			verifica=false;
		}

	}

	IEnumerator Wait(string cena)
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(cena);
	}

	public void Sair()
	{
		Application.Quit();
	}
}