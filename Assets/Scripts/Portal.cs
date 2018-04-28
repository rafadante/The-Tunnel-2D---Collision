using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Portal : MonoBehaviour 
{

	public bool libera=true;
	private string objeto;

	private void OnTriggerEnter2D(Collider2D other) 
	{
		if(libera)
		{
			if(other.gameObject.tag=="Player1")
			{
				if(this.name=="portal_1A")
				{
					other.transform.position =  GameObject.Find("portal_1B").transform.position;
					GameObject.Find("portal_1B").GetComponent<Portal>().libera=false;
					objeto = "portal_1B";
					StartCoroutine(Wait());
				}
				else if(this.name=="portal_1B")
				{
					other.transform.position =  GameObject.Find("portal_1A").transform.position;
					GameObject.Find("portal_1A").GetComponent<Portal>().libera=false;
					objeto = "portal_1A";
					StartCoroutine(Wait());
				}	
				else if(this.name=="portal_2A")
				{
					other.transform.position =  GameObject.Find("portal_2B").transform.position;
					GameObject.Find("portal_2B").GetComponent<Portal>().libera=false;
					objeto = "portal_2B";
					StartCoroutine(Wait());
				}
				else if(this.name=="portal_2B")
				{
					other.transform.position =  GameObject.Find("portal_2A").transform.position;
					GameObject.Find("portal_2A").GetComponent<Portal>().libera=false;
					objeto = "portal_2A";
					StartCoroutine(Wait());
				}
				else if(this.name=="portal_3A")
				{
					other.transform.position =  GameObject.Find("portal_3B").transform.position;
					GameObject.Find("portal_3B").GetComponent<Portal>().libera=false;
					objeto = "portal_3B";
					StartCoroutine(Wait());
				}	
				else if(this.name=="portal_3B")
				{
					other.transform.position =  GameObject.Find("portal_3A").transform.position;
					GameObject.Find("portal_3A").GetComponent<Portal>().libera=false;
					objeto = "portal_3A";
					StartCoroutine(Wait());
				}
				else if(this.name=="portal_4A")
				{
					other.transform.position =  GameObject.Find("portal_4B").transform.position;
					GameObject.Find("portal_4B").GetComponent<Portal>().libera=false;
					objeto = "portal_4B";
					StartCoroutine(Wait());
				}	
				else if(this.name=="portal_4B")
				{
					other.transform.position =  GameObject.Find("portal_4A").transform.position;
					GameObject.Find("portal_4A").GetComponent<Portal>().libera=false;
					objeto = "portal_4A";
					StartCoroutine(Wait());
				}
				else if(this.name=="portal_5A")
				{
					other.transform.position =  GameObject.Find("portal_5B").transform.position;
					GameObject.Find("portal_5B").GetComponent<Portal>().libera=false;
					objeto = "portal_5B";
					StartCoroutine(Wait());
				}	
				else if(this.name=="portal_5B")
				{
					other.transform.position =  GameObject.Find("portal_5A").transform.position;
					GameObject.Find("portal_5A").GetComponent<Portal>().libera=false;
					objeto = "portal_5A";
					StartCoroutine(Wait());
				}
				else if(this.name=="portal_6A")
				{
					other.transform.position =  GameObject.Find("portal_6B").transform.position;
					GameObject.Find("portal_6B").GetComponent<Portal>().libera=false;
					objeto = "portal_6B";
					StartCoroutine(Wait());
				}	
				else if(this.name=="portal_6B")
				{
					other.transform.position =  GameObject.Find("portal_6A").transform.position;
					GameObject.Find("portal_6A").GetComponent<Portal>().libera=false;
					objeto = "portal_6A";
					StartCoroutine(Wait());
				}
			}
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1);
		GameObject.Find(objeto).GetComponent<Portal>().libera=true;
	}
}