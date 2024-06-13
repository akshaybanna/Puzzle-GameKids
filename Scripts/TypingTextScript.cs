using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypingTextScript : MonoBehaviour {

	public static TypingTextScript instance;
	float delay =0.2f;
	public string FullText;

	private string currentText="";
	public Text _text;

	void Awake()
	{
		instance = this;
	}

	void Start () {
		_text = GetComponent<Text> ();
	}
	
	public void showtext()
	{
		StartCoroutine ("texteffect");
	}
	public void cleartext()
	{
	//	print ("opopo");
		_text.text = "";
	}
	IEnumerator texteffect()
	{
		for (int i = 0; i < FullText.Length+1 ; i++) 
		{
			//print(i+gameObject.name);
			currentText = FullText.Substring (0, i);
			_text.text = currentText;
			yield return new WaitForSeconds (delay);
			//we "ll set active false here;;
			//new WaitForSeconds (2f);
			//yield return new WaitForSeconds (2f);
           

		}
       // CameraContoller.CameraContollerInstance.Buttonon();
       // print(CameraContoller.CameraContollerInstance.AnimalIndex);
    }
}
