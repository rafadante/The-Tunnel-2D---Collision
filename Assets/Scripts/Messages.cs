using UnityEngine;
using UnityEngine.SceneManagement;

public class Messages : MonoBehaviour {

	public GameObject pause;

	public void ButtonPause()
	{
		pause.SetActive(true);
		GameObject.Find("Robot_A").GetComponent<RobotController>().ganhou = true;
		GameObject.Find("Robot_B").GetComponent<RobotController>().ganhou = true;
	}

	public void ButtonContinue()
	{
		pause.SetActive(false);
		GameObject.Find("Robot_A").GetComponent<RobotController>().ganhou = false;
		GameObject.Find("Robot_B").GetComponent<RobotController>().ganhou = false;
	}
}