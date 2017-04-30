using UnityEngine;
using System.Collections;

public class DestTrigBottle : MonoBehaviour {
	public GameObject obj;

	private void OnTriggerEnter(Collider other){
		if (other.CompareTag("Bottle") || other.CompareTag("Glass")) {
			Destroy (other.gameObject);
			if(!Shooter.isGameOver){
				Shooter health = obj.transform.GetComponent<Shooter>();
				Shooter.Health-=1;
			}
		}
		else {
			Destroy (other.gameObject);
		}
	}


}
