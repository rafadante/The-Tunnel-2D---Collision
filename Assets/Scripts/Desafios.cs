using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desafios : MonoBehaviour {

	public void Admin(RobotController robot)
	{
		if(robot.level==2)
		{
			Stage_1();
		}
		else if(robot.level==3)
		{
			Stage_2();
		}
		else if(robot.level==4)
		{
			Stage_3();
		}
		else if(robot.level==5)
		{
			Stage_4();
		}
		else if(robot.level==6)
		{
			Stage_5();
		}
		else if(robot.level==7)
		{
			Stage_6();
		}
		else if(robot.level==8)
		{
			Stage_7();
		}
		else if(robot.level==9)
		{
			Stage_8();
		}
		else if(robot.level==10)
		{
			Stage_9();
		}
		else if(robot.level==11)
		{
			Stage_10();
		}
		else if(robot.level==12)
		{
			Stage_11();
		}
		else if(robot.level==13)
		{
			Stage_12();
		}
		else if(robot.level==14)
		{
			Stage_13();
		}
		else if(robot.level==15)
		{
			Stage_14();
		}
		else if(robot.level==16)
		{
			Stage_15();
		}
		else if(robot.level==17)
		{
			Stage_16();
		}
		else if(robot.level==18)
		{
			Stage_17();
		}
		else if(robot.level==19)
		{
			Stage_18();
		}
		else if(robot.level==20)
		{
			Stage_19();
		}
		else if(robot.level==21)
		{
			Stage_20();
		}
	}

	private void Stage_1() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars1" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check1" + player, 1);

			if(PlayerPrefs.GetFloat("Time1" + player)<8)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check1" + player, 2);
			}
		}
	}
	
	private void Stage_2() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars2" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check2" + player, 1);

			if(PlayerPrefs.GetFloat("Time2" + player)<18.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check2" + player, 2);
			}
		}
	}

	private void Stage_3() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars3" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check3" + player, 1);

			if(PlayerPrefs.GetFloat("Time3" + player)<13.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check3" + player, 2);
			}
		}
	}

	private void Stage_4() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars4" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check4" + player, 1);

			if(PlayerPrefs.GetFloat("Time4" + player)<25.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check4" + player, 2);
			}
		}
	}

	private void Stage_5() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars5" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check5" + player, 1);

			if(PlayerPrefs.GetFloat("Time5" + player)<35.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check5" + player, 2);
			}
		}
	}

	private void Stage_6() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars6" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check6" + player, 1);

			if(PlayerPrefs.GetFloat("Time6" + player)<45.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check6" + player, 2);
			}
		}
	}

	private void Stage_7() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars7" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check7" + player, 1);

			if(PlayerPrefs.GetFloat("Time7" + player)<12.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check7" + player, 2);
			}
		}
	}

	private void Stage_8() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars8" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check8" + player, 1);

			if(PlayerPrefs.GetFloat("Time8" + player)<75.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check8" + player, 2);
			}
		}
	}

	private void Stage_9() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars9" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check9" + player, 1);

			if(PlayerPrefs.GetFloat("Time9" + player)<55.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check9" + player, 2);
			}
		}
	}

	private void Stage_10() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars10" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check10" + player, 1);

			if(PlayerPrefs.GetFloat("Time10" + player)<40.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check10" + player, 2);
			}
		}
	}

	private void Stage_11() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars11" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check11" + player, 1);

			if(PlayerPrefs.GetFloat("Time11" + player)<120.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check11" + player, 2);
			}
		}
	}

	private void Stage_12() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars12" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check12" + player, 1);

			if(PlayerPrefs.GetFloat("Time12" + player)<90.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check12" + player, 2);
			}
		}
	}

	private void Stage_13() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars13" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check13" + player, 1);

			if(PlayerPrefs.GetFloat("Time13" + player)<35.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check13" + player, 2);
			}
		}
	}
	private void Stage_14() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars14" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check14" + player, 1);

			if(PlayerPrefs.GetFloat("Time14" + player)<85.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check14" + player, 2);
			}
		}
	}

	private void Stage_15() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars15" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check15" + player, 1);

			if(PlayerPrefs.GetFloat("Time15" + player)<70.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check15" + player, 2);
			}
		}
	}

	private void Stage_16() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars16" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check16" + player, 1);

			if(PlayerPrefs.GetFloat("Time16" + player)<70.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check16" + player, 2);
			}
		}
	}

	private void Stage_17() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars17" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check17" + player, 1);

			if(PlayerPrefs.GetFloat("Time17" + player)<40.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check17" + player, 2);
			}
		}
	}
	private void Stage_18() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars18" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check18" + player, 1);

			if(PlayerPrefs.GetFloat("Time18" + player)<35.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check18" + player, 2);
			}
		}
	}

	private void Stage_19() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars19" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check19" + player, 1);

			if(PlayerPrefs.GetFloat("Time19" + player)<55.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check19" + player, 2);
			}
		}
	}

	private void Stage_20() 
	{
		int player = PlayerPrefs.GetInt("UserNumber")+1;
		if(PlayerPrefs.GetInt("Stars20" + player)==3)
		{
			GameObject.Find("check_1").GetComponent<Image>().enabled=true;
			PlayerPrefs.SetInt("Check20" + player, 1);

			if(PlayerPrefs.GetFloat("Time20" + player)<40.0f)
			{
				GameObject.Find("check_2").GetComponent<Image>().enabled=true;
				PlayerPrefs.SetInt("Check20" + player, 2);
			}
		}
	}
}
