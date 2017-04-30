using UnityEngine;
using System.Collections;

public class AddForceBootle : MonoBehaviour {
	public Rigidbody projectile;
	public Rigidbody projectile2;
	public Rigidbody projectile3;
	public Rigidbody[] glass = new Rigidbody[4];
	public Transform shotPos;
	public float shotForce = 700;
	public GameObject obj;

	private int nBomb;
	private int nAmmo;
	private GameObject person;
	
	
	void Start(){
		person = GameObject.FindWithTag("Player");
	}
	void Update () {
	}

	public void AddBottle(){
		if (Shooter.Score < 30) {
			nBomb = 7;
			nAmmo = 10;
		} else {
			if (Shooter.Score < 50) { nBomb = 6; nAmmo = 11;}
		}
		VyborMesta count = obj.GetComponent<VyborMesta>();
		Rigidbody shot;
		if (count.counterBomb == nBomb ){
			if (count.counterAmmo == nAmmo) {count.counterAmmo-=2;}
			shot = Instantiate (projectile3, shotPos.position,shotPos.rotation)as Rigidbody;
			count.counterBomb = 0;
		}
		else{
			if (count.counterAmmo == nAmmo) {
				count.counterAmmo = 0;
				shot = Instantiate (projectile2, shotPos.position,shotPos.rotation)as Rigidbody;
			}
			else{
				float n = Random.value;
				if(n>0.5)
					shot = Instantiate (projectile, shotPos.position,projectile.rotation)as Rigidbody;
				else{
					int el=Random.Range(0,4);
					Rigidbody gl = glass[el];
					shot = Instantiate (gl, shotPos.position,gl.rotation)as Rigidbody;
				}
		   }
		}
		shot.AddForce (shotPos.up * shotForce);
		person.GetComponent<Shooter> ().playAudioFling ();

	}
}

