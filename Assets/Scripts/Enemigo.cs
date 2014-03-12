using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour {

	public Vector2 force;
	public int hp;

	// Use this for initialization
	void Start () {
		hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(hp<=0||transform.position.y >=10)
		{
			removeMe();
		}
		rigidbody2D.velocity = force;

	}

	void OnCollisionEnter2D(Collision2D theCollision) {
		if (theCollision.gameObject.name.Equals("Pared1")) {
			force.y *= -1;
		}
		if (theCollision.gameObject.name.Equals("Pared2")) {
			force.x*=-1;
		}
		if (theCollision.gameObject.name.Equals("Pared3")) {
			force.y*=-1;
		}
		if (theCollision.gameObject.name.Equals("Pared4")) {
			force.x*=-1;
		}
	}

	void removeMe ()
	{
		Destroy(gameObject);
	}
}
