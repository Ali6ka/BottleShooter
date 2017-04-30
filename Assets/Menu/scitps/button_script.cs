using UnityEngine;
using System.Collections;

public class button_script : MonoBehaviour {

	public GameObject settings;

	public void LoadNewGame(){
		Shooter.Health = 5;
		Shooter.Ammo = 25;
		Shooter.Score = 0;
		Shooter.isGameOver = false;
		Application.LoadLevel ("Shoot");
		Time.timeScale = 1f;
	}
	public void ExitButtonPressed(){
		Application.Quit ();
	}
	//in game scripts
	public void DisplayInGameMenu(){
		gameObject.SetActive(true);
		Time.timeScale = 0f;
	}
	public void Continue(){
		gameObject.SetActive(false);
		ResetTimeScale (0);

	}

	public void OpenSettingsMenu(){
		gameObject.SetActive (false);
		settings.SetActive (true);
	}

	public void BackFromSettings(){
		gameObject.SetActive (true);
		settings.SetActive (false);
	}

	public void ResetTimeScale(double t){
		if (t != 1f) {
			Time.timeScale = 0.01f;
			Invoke ("ResetTime", 0.04f);
		}
	}
	public void ResetTime(){
		Time.timeScale = 1f;
	}
	public void LoadMainMenu(){
		Time.timeScale = 1f;
		Application.LoadLevel ("menu1");
	}
}
