using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*Classe responsável pelo comportamento da bala */
public class Enemy_01 : MonoBehaviour {

	float time=3.0f;//velocidade da bala
	private int life=40;
	public GameObject bullet, explosion;//prefab com a animação da explosão
	public Transform muzle1, muzle2;
	bool verifica;

	private void Start() 
	{
		if(SceneManager.GetActiveScene().name=="stage_10")
			life = 40;
		else if(SceneManager.GetActiveScene().name=="stage_20")
			life = 75;
	}

	void Update() {
		if(SceneManager.GetActiveScene().name=="stage_10")
		{
			if(!verifica)
			{	
				StartCoroutine(Wait());
				verifica=true;
			}

			if(life<=25 && life>10)
			{
				time = 2.0f;
				GetComponent<SpriteRenderer>().color= new Color(255,255,0);
			}
			else if(life <= 10 && life>0)
			{
				time = 0.5f;
				GetComponent<SpriteRenderer>().color= new Color(255,0,0);
			}
			else if(life<=0)
			{
				Destroy(this.gameObject);
				Instantiate(explosion, this.transform.position, this.transform.rotation);
			}
		}
		else if(SceneManager.GetActiveScene().name=="stage_20")
		{
			if(!verifica)
			{	
				StartCoroutine(Wait());
				verifica=true;
			}

			if(life<=50 && life>25)
			{
				time = 2.0f;
				GetComponent<SpriteRenderer>().color= new Color(255,255,0);
			}
			else if(life <= 25 && life>0)
			{
				time = 0.5f;
				GetComponent<SpriteRenderer>().color= new Color(255,0,0);
			}
			else if(life<=0)
			{
				Destroy(this.gameObject);
				Instantiate(explosion, this.transform.position, this.transform.rotation);
			}
		}
		else
		{
			if(life>15 && life<30)
			{
				GetComponent<SpriteRenderer>().color= new Color(255,255,0);
			}
			else if(life>0 && life<=15)
			{
				GetComponent<SpriteRenderer>().color= new Color(255,0,0);
			}
			else if(life<=0)
			{
				Destroy(this.gameObject);
				Instantiate(explosion, this.transform.position, this.transform.rotation);
			}
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(time);
		Instantiate(bullet, muzle1.transform.position, Quaternion.Euler(new Vector3(0, 0, 1)));
		Instantiate(bullet, muzle2.position, muzle2.rotation);
		verifica=false;
	}

	private void OnTriggerEnter2D(Collider2D other) 
	{
		if(SceneManager.GetActiveScene().name=="stage_10" || SceneManager.GetActiveScene().name=="stage_20")
		{
			if(other.gameObject.tag=="obstaculo")
			{
				StartCoroutine(TomouDano());
				life--;
				if(this.name=="enemy_01")
					GameObject.Find("green_1").transform.localScale = new Vector3(life*0.05f, 0.25f, 1);
				else if(this.name=="enemy_02")
					GameObject.Find("green_2").transform.localScale = new Vector3(life*0.05f, 0.25f, 1);
			}
		}
		else
		{
			if(other.gameObject.tag=="obstaculo")
				life = life - 8;
		}
	}

	IEnumerator TomouDano()//faz o jogador piscar quando colidir com um obstaculo
	{
		for(int i = 0; i < 5; i++)
		{
			GetComponent<SpriteRenderer>().enabled = false;	
			yield return new WaitForSeconds(0.05f);
			GetComponent<SpriteRenderer>().enabled = true;
			yield return new WaitForSeconds(0.05f);
		}
	}
}