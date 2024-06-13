using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AnimalPartScript : MonoBehaviour {
	public static AnimalPartScript Instance;
	public List<GameObject> partlist;

	public int PartIndex;


	void Awake()
	{
		Instance = this;
	}
	void Start () 
	{
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			gameObject.transform.GetChild (i).GetComponent<SpriteRenderer> ().color= new Color(255,255,255,0);
			partlist.Add (gameObject.transform.GetChild (i).gameObject);
			//print(i + gameObject.name);
           
        }

		gameObject.transform.parent.GetChild (0).GetComponent<SpriteRenderer> ().color =  new Color(255,255,255,0);
		//print( gameObject.name + "fiks");
		
        StartCoroutine (Fadeout ());
    }

	float i;
	IEnumerator Fadeout()
	{
		yield return new WaitForSeconds (.01f);
		i += .01f;
		for (int j = 0; j < gameObject.transform.childCount; j++) 
		{
			gameObject.transform.GetChild (j).GetComponent<SpriteRenderer> ().color= new Color(255,255,255,i);
			//print(j + "point");
		}
		gameObject.transform.parent.GetChild (0).GetComponent<SpriteRenderer> ().color =  new Color(255,255,255,i);
		if (i <= 1)
			//print(i + " ten");
			StartCoroutine (Fadeout ());  
    }
}
