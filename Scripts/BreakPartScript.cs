using UnityEngine;
using System.Collections;

public class BreakPartScript : MonoBehaviour {
	int inde;
	Vector3 startingPos;
	Vector3[] startPOSI; 
	bool IsBreak;
	// Use this for initialization
	void Start () {
		startingPos = transform.position;
		StartCoroutine (BreakPart ());
	}
	
	// Update is called once per frame
	void Update () {


		if (IsBreak) {
			
			transform.position = Vector3.MoveTowards (transform.position, StartList.StartListInstance.partlist [int.Parse (gameObject.name)].transform.position, Time.deltaTime * 40);
			float f = Vector3.Distance (transform.position, StartList.StartListInstance.partlist [int.Parse (gameObject.name)].transform.position);
			//print (f + (gameObject.name));
			if (f < .5f) {
				
				gameObject.SetActive (false); 
				StartList.StartListInstance.partlist [int.Parse (gameObject.name)].gameObject.SetActive (true);
				gameObject.transform.position = startingPos;
				//print (startingPos + "AKSHAY");
				gameObject.GetComponent<BreakPartScript>().enabled = false;
				StartFunctionity (true);
				UIManager.Instance.ObjectBg_panal.SetActive (true);
				Vibration.Vibrate(200);
				//CameraContoller.CameraContollerInstance.txttt.SetActive(true);

            }
		}

	}


	IEnumerator BreakPart()
	{
		StartFunctionity (false);
		yield return new WaitForSeconds (2f);
		IsBreak=true;
		SoundManager.instance.ExploresoundPlay();
	//	print("ijiejed" + gameObject.name);
	}

	void StartFunctionity(bool istrue)
	{
		for (int i = 0; i < StartList.StartListInstance.partlist.Count; i++) 
		{
			//print(i +"yturie"); 
//			StartList.StartListInstance.partlist [i].GetComponent<RelativeJoint2D> ().enabled = istrue;
//			StartList.StartListInstance.partlist [i].GetComponent<Rigidbody2D> ().isKinematic = !istrue;
		}
	}
}
