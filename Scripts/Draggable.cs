using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour{

	private Vector3 origin;
	private float forceConstant = 120;
	private bool returning = false;
	private float precision = 0.1f;

	Vector3 offset;
	private void Start(){
		origin = transform.position;
	}

	private void Update(){
		if (Input.GetMouseButton(0))
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) ;
			transform.position = curPosition;
		}
		if (Input.GetMouseButtonUp(0)){
			returning = true;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		}

		if (returning){
			GetComponent<Rigidbody>().AddForce (forceConstant*(origin - transform.position));
			GetComponent<Rigidbody>().velocity *= 0.9f;
			
			if (GetComponent<Rigidbody>().velocity.magnitude < precision && 
				Vector3.Distance(transform.position, origin) < precision){
				
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
				returning = false;
			}
		}
	}
}