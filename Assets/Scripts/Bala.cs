using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	private float moveSpeed = 15f; // how fast the bullet moves
	private float timeSpentAlive; // how long the bullet has stayed alive for

	void Start () {

	}

	void Update () {
		timeSpentAlive += Time.deltaTime;
		if (timeSpentAlive > 3)
		{
			removeMe();
		}
		transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

	}
	void removeMe ()
	{
		Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<Enemigo>()!=null)
		{
			Enemigo enemigo = (Enemigo)other.gameObject.GetComponent<Enemigo>();
			enemigo.hp -= 20;
		}
		removeMe ();
	}
}