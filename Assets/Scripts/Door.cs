using UnityEngine;

public class Door : MonoBehaviour {

	private Sprite sprite1, sprite2, sprite3;
	public bool door, acessou;
	private bool repetir;
	private AudioClip som_gravidade, som_win;

	private void Start() {
		sprite1 = Resources.Load<Sprite> ("DoorLocked");
		sprite2 = Resources.Load<Sprite> ("DoorUnlocked");
		sprite3 = Resources.Load<Sprite> ("DoorOpen");

		som_gravidade = Resources.Load("gravidade") as AudioClip;
	}

	private void Update() {
		if(GameObject.Find("DoorLocked_A").GetComponent<Door>().door && GameObject.Find("DoorLocked_B").GetComponent<Door>().door && !repetir)
		{
			GetComponent<SpriteRenderer>().sprite = sprite3;
			acessou = true;
			repetir=true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")//se o jogador colidir com a porta locked	
		{
			GetComponent<AudioSource>().PlayOneShot(som_gravidade);
			GetComponent<SpriteRenderer>().sprite = sprite2;
			door = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")//se o jogador colidir com a porta locked	
		{
			GetComponent<AudioSource>().PlayOneShot(som_gravidade);
			GetComponent<SpriteRenderer>().sprite = sprite1;
			door = false;
		}
	}
}
