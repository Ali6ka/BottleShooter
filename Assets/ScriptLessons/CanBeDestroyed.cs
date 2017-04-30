using UnityEngine;
using System.Collections;

public class CanBeDestroyed : MonoBehaviour {
	public GameObject destroyed;
	private GameObject person;
	private int n;
	private int mode;
	private int rot;

	void Start(){
		person = GameObject.Find("MainPerson");
		rot = Random.Range (1, 4);
	}

	void Update(){
		if (transform.CompareTag ("Bottle")) {
			if (rot == 1) {transform.Rotate (new Vector3 (Time.deltaTime, Time.deltaTime * 100, Time.deltaTime * 30));} 
			else if (rot == 2) {transform.Rotate (new Vector3 (Time.deltaTime, Time.deltaTime, Time.deltaTime * 200));} 
			else if (rot == 3) {transform.Rotate (new Vector3 (Time.deltaTime, Time.deltaTime, -(Time.deltaTime * 200)));}
		} else if (transform.CompareTag ("Finish")) {transform.Rotate (new Vector3 (Time.deltaTime, Time.deltaTime * 100, Time.deltaTime * 30));}
	}

	public void OnMouseDown(){  
		if (Time.timeScale == 1 && !Shooter.isGameOver) {
			if(gameObject.CompareTag("Bottle")|| gameObject.CompareTag("Glass")){
				person.GetComponent<Shooter>().playAudioBottle();
				Shooter.Score++;
			} 
			else if (gameObject.CompareTag("AddAmmo")) {
					Shooter.Ammo += 10;
					person.GetComponent<Shooter>().playAudioReload();
			}
			else if(gameObject.CompareTag("Finish"))
				person.GetComponent<Shooter>().explode();			
			Activate();
		}
	}

	public void Activate() {  //changes item to destroyed form;
			Instantiate (destroyed, transform.position, transform.rotation);
			Destroy (gameObject);
	}
}