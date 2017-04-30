using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shooter : MonoBehaviour {
	public static int Health = 5;
	public static int Ammo = 25;
	public static int Score = 0;

	public GameObject RecordText;
	public Transform shotPos;

	public static bool isGameOver;
	public Text gameOverScoreText;
	public Text highScoreText;

	public AudioClip Fire;
	public AudioClip Reload;
	public AudioClip Bottle;
	public AudioClip Explosion;
	public AudioClip BeforeExp;
	public AudioClip Fling;

	public GUIText AmmoGui;
	public GUIText ScoreGui;
	public GUIText HealthGui;
	public Transform metalHit;

	public GameObject gameOverMenu;
	public Transform Sparks;

	private float MoveSpeed = 30f;
	private float RotateSpeed = 80f;
	private Vector2 hotSpot; 
	private Camera cam;
	private int highestScore;
	private RaycastHit Hit;

	void Start () {
		//курсор
		//hotSpot = new Vector2 (cursorTexture.width/2, cursorTexture.height/2);
		//Cursor.SetCursor (cursorTexture, hotSpot, CursorMode.Auto);
		highestScore = PlayerPrefs.GetInt("HighestScore");
		cam = Camera.main;
		isGameOver = false;
	}
		
	void Update () {


		// вращение в сторону пррицела
		Vector3 Mouse = Input.mousePosition;
		Mouse.z = -cam.transform.position.z;
		Vector3 target = cam.GetComponent<Camera>().ScreenToWorldPoint (Mouse);
		transform.LookAt (target);
		//
		if (Input.GetButtonDown("Fire1") && Ammo > 0 && Time.timeScale == 1f && !isGameOver) {
			Ammo -= 1;
			GetComponent<AudioSource>().PlayOneShot(Fire,0.5f);
			Vector3 Direction = shotPos.TransformDirection(Vector3.forward);
			if(Physics.Raycast(shotPos.position, Direction, out Hit, 1000f))
			{
				Quaternion HitRotation = Quaternion.FromToRotation(Vector3.forward, Hit.normal);
				if(Hit.transform.name == "back"){
					Transform metalhitGO = Instantiate(metalHit,Hit.point+(Hit.normal*0.001f),HitRotation) as Transform;
					metalhitGO.transform.parent = Hit.transform;
					Destroy((metalhitGO as Transform).gameObject, 8); 
					Instantiate(Sparks,Hit.point+(Hit.normal*0.001f),HitRotation);
				}
			}

			AmmoGui.text = "Патроны: "+Ammo.ToString();
		}

		if (Health <= 0 || Ammo <=0) {
			if(Score > highestScore){
				PlayerPrefs.SetInt("HighestScore", Score);
				RecordText.SetActive(true);
			}
			if(isGameOver == false){
				gameOverScoreText.text = Score.ToString();
				highScoreText.text = PlayerPrefs.GetInt("HighestScore").ToString();
				GetGameOverMenu();
				isGameOver = true;
			}
		}
	}


	//addition methods
	public void playAudioBottle(){
		GetComponent<AudioSource>().PlayOneShot(Bottle,2f);
	}
	public void playAudioReload(){
		GetComponent<AudioSource>().PlayOneShot(Reload,3f);
	}
	public void playAudioExplosion(){
		GetComponent<AudioSource>().PlayOneShot(Explosion,3f);
	}
	public void playAudioFling(){
		GetComponent<AudioSource>().PlayOneShot(Fling,0.5f);
	}
	//end

	//bomb explosion methods
	public void explode(){
		GetComponent<AudioSource> ().PlayOneShot (BeforeExp, 3f);
		shakeCamera ();
		GameObject.Find ("MestaVyleta").SetActive (false);
		wait ("darkAndSound", 3f);
	}
	private void darkAndSound(){
		cam.cullingMask = 0;
		playAudioExplosion ();
		wait ("setCullingMask", 5f);
	}
	private void setCullingMask(){
		cam.cullingMask = 1;
		Health = 0;
	} 
	//end

	public void shakeCamera(){
		cam.gameObject.AddComponent<CameraShake> ();
	}

	private void wait(string method, float n){
		Invoke (method, n);
	}

	private void OnGUI(){ //вывод инфо(патороны очки)
		AmmoGui.text = "Патроны: "+Ammo.ToString();
		ScoreGui.text = Score.ToString ();
		HealthGui.text = Health.ToString ();
	}
	private void GetGameOverMenu(){
		gameOverMenu.GetComponent<Animation>().Play();
	}
}
