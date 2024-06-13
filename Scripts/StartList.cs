using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class StartList : MonoBehaviour 
{
	public List<GameObject> partlist;
	
	public static StartList StartListInstance;
	
	void Awake()
	{
		StartListInstance = this;
	}
	void Start ()
	{
		for (int i = 0; i < gameObject.transform.childCount; i++) 
		{
			//print(i + gameObject.name) ;
			partlist.Add (gameObject.transform.GetChild (i).gameObject);
            //Debug.Log("Movable child = " + gameObject.transform.GetChild(i).gameObject.name);
           
        }
	}
}
