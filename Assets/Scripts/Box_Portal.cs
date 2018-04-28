using UnityEngine;

public class Box_Portal : MonoBehaviour {

	private void OnTriggerStay2D(Collider2D other) 
	{
		if(GameObject.Find("portal_1(Clone)") && GameObject.Find("portal_2(Clone)"))
		{
			if(other.gameObject.name == "portal_1(Clone)")
			{
				if(GameObject.Find("portal_2(Clone)"))
					transform.position = new Vector2(GameObject.Find("portal_2(Clone)").transform.position.x-2, GameObject.Find("portal_2(Clone)").transform.position.y);
			}
			else if(other.gameObject.name == "portal_2(Clone)")
			{
				if(GameObject.Find("portal_1(Clone)"))
					transform.position = new Vector2(GameObject.Find("portal_1(Clone)").transform.position.x-2, GameObject.Find("portal_1(Clone)").transform.position.y);
			}
		}
	}
}