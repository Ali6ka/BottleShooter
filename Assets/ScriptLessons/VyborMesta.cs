using UnityEngine;
using System.Collections;


public class VyborMesta : MonoBehaviour {

	public int counterAmmo = 0;
	public int counterBomb = 0;
	public GameObject[] places = new GameObject[4];
	public Transform parent;

	private string choice;
	private string lastchoice;
	private float timeToWait;

	private bool x_sub;
	private int n;
	private int x;
	
	void Start () {
		x = 25; n = 0;
		timeToWait = 5f;
		Debug.Log("TimeToWait: " + timeToWait.ToString());
		waitTime();
	}

	void Update () {
	}

	public void switchOff(){
		parent.gameObject.SetActive (false);
	}

	private void waitTime(){
		x_sub = false;
		counterBomb++; 
		counterAmmo++;
		if (Shooter.Score > x && timeToWait>2 && x_sub == false){ // throw bottle faster
			timeToWait-=1;
			x+=25;
			Debug.Log("TimeToWait: " + timeToWait.ToString());
		} 
		n = Random.Range (1, 11); 
		//Debug.Log ("random n: " + n.ToString ());
		//randomly choose the amount of places that will throw bottle. begin;
			if (n==2 || n==4 || n==6) {n=1;}
			else if(n==3 || n==9 || n==1) {n=2;}
			else if(n==5 || n==7 || n==8){n=3;}
			else if(n==10){n=4;}
		//end
		Invoke ("ChoosePlace", timeToWait);
	}

	private void ChoosePlace(){
		//Debug.Log ("places n: " + n.ToString ());
		if (n==1) {
			choice = Random.Range (1, 5).ToString ();
			if (choice != lastchoice) { 
				lastchoice = choice;
				GameObject activ = GameObject.FindWithTag (choice);
				activ.GetComponent<AddForceBootle> ().AddBottle ();
			} else {
				lastchoice="0";
				ChoosePlace();
				return;
			}
		} else {
			int counter=0;
			while(counter<n){
				counter++;
				GameObject.FindWithTag(counter.ToString()).GetComponent<AddForceBootle>().AddBottle();
			}
		}
		waitTime ();
	}	
}
