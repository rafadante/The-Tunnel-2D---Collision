using UnityEngine;

public class PortalUnlock : MonoBehaviour 
{

	public int portal2_cont, portal3_cont=0, portal4_cont;
	public GameObject portal1, portal2, portal3, portal4; 

	public void DesbloqueiaPortal1 () 
	{
		portal1.SetActive(true);
	}
	
	public void DesbloqueiaPortal2 () 
	{
		portal2_cont++;
		if(portal2_cont==2)
			portal2.SetActive(true);
	}

	public void DesbloqueiaPortal3 () 
	{
		portal3_cont++;
		if(portal3_cont==3)
			portal3.SetActive(true);
	}

	public void DesbloqueiaPortal4 () 
	{
		portal4_cont++;
		if(portal4_cont==4)
			portal4.SetActive(true);
	}
}