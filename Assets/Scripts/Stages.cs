using UnityEngine;
using UnityEngine.SceneManagement;
/*Classe que administra a gravidade e o estado tiro inicial do jogador em cada nivel */
public class Stages : MonoBehaviour{

	protected float g_Inicial_PA, g_Inicial_PB;
	protected int initial_time;
	protected float initial_float_time;
	private Scene scene;
	protected bool portal_gun;
	RobotController controller;

	void Start () 
	{
		controller = GetComponent<RobotController> ();
		scene = SceneManager.GetActiveScene ();
		VerificaFase ();
	}

	public void VerificaFase()
	{
		switch (scene.name)
		{
			case "stage_1":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 15;
				initial_float_time = 15.0f;
				portal_gun=false;
				break;
			case "stage_2":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 25;
				initial_float_time = 25.0f;
				portal_gun=false;
				break;
			case "stage_3":
				g_Inicial_PA = -1;
				g_Inicial_PB = 1;
				initial_time = 15;
				initial_float_time = 15.0f;
				portal_gun=false;
				break;
			case "stage_4":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 35;
				initial_float_time = 35.0f;
				portal_gun=false;
				break;
			case "stage_5":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 50;
				initial_float_time = 50.0f;
				portal_gun=false;
				break;
			case "stage_6":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 60;
				initial_float_time = 60.0f;
				portal_gun=false;
				break;
			case "stage_7":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 25;
				initial_float_time = 25.0f;
				portal_gun=false;
				break;
			case "stage_8":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 100;
				initial_float_time = 100.0f;
				portal_gun=false;
				break;
			case "stage_9":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 75;
				initial_float_time = 75.0f;
				portal_gun=false;
				break;
			case "stage_10":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 120;
				initial_float_time = 120.0f;
				break;
			case "stage_11":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 180;
				initial_float_time = 180.0f;
				portal_gun=false;
				break;
			case "stage_12":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 80;
				initial_float_time = 80.0f;
				portal_gun=true;
				break;
			case "stage_13":
				g_Inicial_PA = -1;
				g_Inicial_PB = 1;
				initial_time = 50;
				initial_float_time = 50.0f;
				portal_gun=false;
				break;
			case "stage_14":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 100;
				initial_float_time = 100.0f;
				portal_gun=true;
				break;
			case "stage_15":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 90;
				initial_float_time = 90.0f;
				portal_gun=false;
				break;
			case "stage_16":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 85;
				initial_float_time = 85.0f;
				portal_gun=false;
				break;
			case "stage_17":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 55;
				initial_float_time = 55.0f;
				portal_gun=false;
			break;
			case "stage_18":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 50;
				initial_float_time = 50.0f;
				portal_gun=false;
			break;
			case "stage_19":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 65;
				initial_float_time = 65.0f;
				portal_gun=false;
			break;
			case "stage_20":
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				initial_time = 120;
				initial_float_time = 120.0f;
			break;
			default:
				g_Inicial_PA = 1;
				g_Inicial_PB = 1;
				break;
		}
		controller.Gravidade (g_Inicial_PA, g_Inicial_PB, initial_time, initial_float_time, portal_gun);
	}
}