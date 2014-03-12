using UnityEngine;
using System.Collections;

public class SpawnPelotas : MonoBehaviour {

	public float cooldown;

	private GameObject objetoSpawner;
	private VariableScript ptrScriptVariable;
	private float cd;

	
	void Start () {
		objetoSpawner = (GameObject) GameObject.FindWithTag ("spawner");
		ptrScriptVariable = (VariableScript) objetoSpawner.GetComponent( typeof(VariableScript) );
		cd = cooldown;
	
	}

	void Update () {
		cd -= Time.deltaTime;

		if(cd <= 0)
		{
			Instantiate(ptrScriptVariable.objBola, transform.position, transform.rotation);
			cd = cooldown;
		}


	
	}
}
