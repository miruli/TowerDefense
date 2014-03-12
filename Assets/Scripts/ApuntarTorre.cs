using UnityEngine;
using System.Collections;

public class ApuntarTorre : MonoBehaviour {

	public float targetAngle;
	public GameObject objTarget;
	
	void Start () {
		targetAngle = 0;
	}

	void Update () { 
		this.transform.Rotate(new Vector3(0,0,targetAngle));
		if(objTarget == null)
		{
			targetAngle = -transform.rotation.z;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (objTarget==null) {
			objTarget = other.gameObject;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (objTarget!=null) 
		{
			if(other.gameObject == objTarget)
			{
				var catOp = 0.0f;
				var catAdy = 0.0f;
				var angle = 0.0f;
				if (objTarget.transform.position.x < this.transform.position.x) {
					if (objTarget.transform.position.y < this.transform.position.y) {
						catOp = this.transform.position.x - objTarget.transform.position.x;
						catAdy = this.transform.position.y - objTarget.transform.position.y;
						angle = Mathf.Atan(catOp/catAdy)*Mathf.Rad2Deg;
						targetAngle = 270 - angle - this.transform.rotation.eulerAngles.z;
					}
					else {
						catOp = this.transform.position.y - objTarget.transform.position.y;
						catAdy = this.transform.position.x - objTarget.transform.position.x;
						angle = Mathf.Atan(catOp/catAdy)*Mathf.Rad2Deg;
						targetAngle = 180 + angle - this.transform.rotation.eulerAngles.z;
					}
				}
				else {
					if (objTarget.transform.position.y < this.transform.position.y) {
						catOp = this.transform.position.y - objTarget.transform.position.y;
						catAdy = this.transform.position.x - objTarget.transform.position.x;
						angle = Mathf.Atan(catOp/catAdy)*Mathf.Rad2Deg;
						targetAngle = 360 + angle - this.transform.rotation.eulerAngles.z;
					}
					else {
						catOp = this.transform.position.x - objTarget.transform.position.x;
						catAdy = this.transform.position.y - objTarget.transform.position.y;
						angle = Mathf.Atan(catOp/catAdy)*Mathf.Rad2Deg;
						targetAngle = 90 - angle - this.transform.rotation.eulerAngles.z;
					}
				}

			}
		}
		else
		{
			objTarget = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		objTarget = null;
		targetAngle = 0;
	}

	public bool TieneTarget()
	{
		if(objTarget!=null)
		{
			return true;
		}
		return false;
	}

	public Quaternion GetAimRotation()
	{
		return transform.rotation;
	}
}