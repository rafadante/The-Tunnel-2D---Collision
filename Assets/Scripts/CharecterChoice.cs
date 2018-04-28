using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharecterChoice : MonoBehaviour {

	public int cont;
	public GameObject char_1, char_2, char_3, ok;

	public void Left()
	{
		if(cont>-2)
		{
			cont--;
			Verifica();
		}
		else
		{
			cont=0;
			Verifica();
		}
	}

	public void Right()
	{
		if(cont<2)
		{
			cont++;
			Verifica();
		}
		else
		{
			cont=0;
			Verifica();
		}
	}

	void Verifica()
	{
		if(cont==0)
		{
			char_1.SetActive(true);
			char_2.SetActive(false);
			char_3.SetActive(false);
			ok.SetActive(true);
		}
		else if(cont==-1 || cont==1)
		{
			char_1.SetActive(false);
			char_2.SetActive(true);
			char_3.SetActive(false);
			ok.SetActive(false);
		}
		else if(cont==-2 || cont==2)
		{
			char_1.SetActive(false);
			char_2.SetActive(false);
			char_3.SetActive(true);
			ok.SetActive(false);
		}
	}
}
