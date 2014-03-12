using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour {

	public float oro;
	public float oroPerSec;
	private Torre selectedTorre;
	private GameObject objJugador;
	private Vector3 posicion;
	private VariableScript ptrScriptVariable;
	private Camera camara;
	// Use this for initialization
	void Start () {
		oro = 0;
		selectedTorre = null;
		camara = transform.FindChild("Main Camera").gameObject.camera;
		objJugador = (GameObject) GameObject.FindWithTag ("jugador");
		posicion = camara.ScreenToWorldPoint (Input.mousePosition);
		posicion.z = 0;
		ptrScriptVariable = (VariableScript) objJugador.GetComponent( typeof(VariableScript) );
	}
	
	// Update is called once per frame
	void Update () {
		oro += oroPerSec * Time.deltaTime;
		posicion = camara.ScreenToWorldPoint (Input.mousePosition);
		posicion.z = 0;
		//-----------INPUTS--------------
		if(Input.GetMouseButtonDown(0))
		{
			if(selectedTorre!=null)
			{
				ComprarTorre(selectedTorre.precio);
				selectedTorre = null;
			}

		}
		//-------------------------------
	}

	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,60), "Torres");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Petita")) {
			//TODO AGREGAR ACA QUE EL SIGUIENTE CLIC PONE UNA TORRE
			selectedTorre = ptrScriptVariable.objTorre.GetComponent<Torre>();
		}

		GUI.Box (new Rect (10, 210, 100, 40), "ORO");
		GUI.Label(new Rect(20, 230, 80, 20), oro.ToString ().Split('.')[0]);
		GUI.Label (new Rect (20, 250, 100, 20), " X:" + Input.mousePosition.x.ToString () + " Y:" + Input.mousePosition.y + ToString ());
	}

	void ComprarTorre(float precio)
	{
		if (oro >= precio) 
		{
			oro -= precio;
			Instantiate(ptrScriptVariable.objTorre, posicion, transform.rotation);
		}
	}

}
