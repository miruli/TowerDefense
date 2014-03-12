using UnityEngine;
using System.Collections;


public class Torre : MonoBehaviour {

	public float precio;
	public float cooldown;
	private float cd;
	private GameObject objTorre;
	private VariableScript ptrScriptVariable;
	private ApuntarTorre at;

	// Use this for initialization
	void Start () {
		resetiarCooldown ();
		objTorre = (GameObject) GameObject.FindGameObjectWithTag ("Torre");
		ptrScriptVariable = (VariableScript) objTorre.GetComponent<VariableScript>();
		at = (ApuntarTorre)GetComponentInChildren<ApuntarTorre>();
	}
	
	// Update is called once per frame
	void Update () {

		cd -= Time.deltaTime;
		if (cd<0&&at.TieneTarget())
		{
			HandleBullets();
			resetiarCooldown ();
		}
	
	}

	void HandleBullets ()
	{
		Instantiate(ptrScriptVariable.objBullet, transform.position, at.GetAimRotation());
	}
	
	void resetiarCooldown()
	{
		cd = cooldown;
	}
}
