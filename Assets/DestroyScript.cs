using UnityEngine;

public class DestroyScript : MonoBehaviour {

	void Start () {
		Invoke("Destroi", 1.0f);
	}
	
	void Destroi () {
		Destroy(gameObject);
	}
}