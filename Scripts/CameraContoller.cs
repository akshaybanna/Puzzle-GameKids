using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.PlayerLoop;
using static UnityEngine.ParticleSystem;

[System.Serializable]	
public class Objects
{
	public string ObjectName;
	public string [] ObjectOFname;

}
[System.Serializable]	
public class GameProperties
{
	public string name;
	public GameObject [] AllAnimalPrefab;

	public GameObject BG;

	public Objects[] ObjectName;

	public Vector3 CameraPosition;

}

public class CameraContoller : MonoBehaviour {

	public static CameraContoller CameraContollerInstance;


	public GameProperties[] games; 



//	public GameObject [] AllAnimalPrefab;
//
//	public string [] HighFlyingAnimalName;
//	public string [] FlyingAnimalName;
//	public string [] GroundAnimalName;
//	public string [] Gound_IceAnimalName;
//	public string [] IceAnimalName;
//	public string [] underWaterAnimalName;
//	public List<string> HighFlyingAnimalName;



	public Vector3 CameraPosition;

	public int AnimalIndex;
	public GameObject CurrnetAnimal;

	public GameObject previosBTN;
	public GameObject buttonNXT;
	public GameObject gameplayPANEL;


    bool IsCameraMove;

	public Transform BgTransform;

	public string selectedGamename;
	public GameObject particle222;
	//public Vector3 baloonPos;
	



    void Awake()
	{
		CameraContollerInstance = this;
	}
	// Use this for initialization
	public void Start () 
	{
		IsCameraMove = false;
		SelectAnimal ();
//		print ("start");
//		AnimalSpawn ();

		setCurrentBg ();


	}
	


	void setCurrentBg()
	{

		switch (selectedGamename) {
		case "AnimalGame":
			BgTransform = games [0].BG.transform;
			break;
		case "VegitableGame":
			BgTransform = games [1].BG.transform;
			break;
		case "FruitsGame":
			BgTransform = games [2].BG.transform;
			break;
		case "BekeryGame":
			BgTransform = games [3].BG.transform;
			break;
		}
		print("back ground check kr");
	}
	
	 IEnumerator wait()
     {
		yield return new WaitForSeconds (1f);
		if (CameraContoller.CameraContollerInstance.selectedGamename == "AnimalGame")
		{
            SoundManager.instance.PlaySound(AnimalIndex);
        }
		if (CameraContoller.CameraContollerInstance.selectedGamename == "VegitableGame")
		{
            SoundManager.instance.vegSound(AnimalIndex);
        }
		if (CameraContoller.CameraContollerInstance.selectedGamename == "FruitsGame")
		{
			SoundManager.instance.fruitssound(AnimalIndex);
		}
		if(CameraContoller.CameraContollerInstance.selectedGamename == "BekeryGame")
		{
			SoundManager.instance.bakerySound (AnimalIndex);
		}
		//SoundManager.instance.PlaySound (AnimalIndex);
		yield return new WaitForSeconds (1f);
        NextElement();
        yield return new WaitForSeconds (5f);
		// yha kaam krna h
		TypingTextScript.instance.cleartext ();
		//NextElement ();
	 }

	
public	void nextWait()
	{
        

            Vector3 position2 = new Vector3(0f, 0f, -200f);

            Instantiate(particle222.gameObject, position2, Quaternion.identity);

            StartCoroutine(wait());
           
        
    }
	//public GameObject particle;
	//public void OnParticle()
	//{
 //       Vector3 collisonPOS = new Vector3(transform.position.x, transform.position.y, -200f);
 //       Instantiate(particle, collisonPOS, Quaternion.identity);
 //   }
	//public void Buttonon()
	//{
 //       previosBTN.SetActive(true);
 //       buttonNXT.SetActive(true);
 //   }
	
	public void Buttonofff()
	{
		buttonNXT.SetActive (false);
		previosBTN.SetActive (false);
	}
	//public GameObject txttt;
	public void NextAnimal()
	{
		UIManager.Instance.ButtonSound ();
		Destroy (CurrnetAnimal);
		
		CheckGreater ();
		AnimalIndex++;
		SelectAnimal ();    
		wait();
        buttonNXT.SetActive(false);
		print("pointyup");
        //previosBTN.SetActive(true);
		//txttt.SetActive(false);

    }
	public void PreAimal()
	{
		UIManager.Instance.ButtonSound ();
		Destroy (CurrnetAnimal);
		
		CheckLesser ();
		AnimalIndex--;
		SelectAnimal ();
      //  previosBTN.SetActive(false);
      //  buttonNXT.SetActive(true);
		//txttt.SetActive(false);

    }

	//public void HomeButton()
	//{
	//	UIManager.Instance.panelBlack.SetActive(true); 
	//	gameplayPANEL.SetActive (false);
	//	UIManager.Instance.ButtonSound ();
	//	if(CurrnetAnimal!=null)
	//	Destroy (CurrnetAnimal);
	//	UIManager.Instance.AllGamepanal [0].SetActive (true);
	//	UIManager.Instance.cameracontroller.enabled = false;
	//	AnimalIndex = 0;
	//	CameraPosition = new Vector3 (0, 0,0);
 //       BgTransform.position = new Vector3 (7.273111f, -10, 5);
       
		
 //   }

	void CheckGreater()
	{
		switch (selectedGamename) {
		case "AnimalGame":
			if (AnimalIndex >= games[0].AllAnimalPrefab.Length - 1)
				AnimalIndex = -1;
			break;
		case "VegitableGame":
			if (AnimalIndex >= games[1].AllAnimalPrefab.Length - 1)	
				AnimalIndex = -1;
			break;
		case "FruitsGame":
			if (AnimalIndex >= games[2].AllAnimalPrefab.Length - 1)
				AnimalIndex = -1;
			break;
		case "BekeryGame":
			if (AnimalIndex >= games[3].AllAnimalPrefab.Length - 1)
				AnimalIndex = -1;
			break;
		}
	}
	void CheckLesser()
	{
		switch (selectedGamename) 
		{
		case "AnimalGame":
			if (AnimalIndex <= 0)
				AnimalIndex = games [0].AllAnimalPrefab.Length;
			break;

		case "VegitableGame":
			if (AnimalIndex <= 0)
				AnimalIndex = games [1].AllAnimalPrefab.Length;
			break;
		case "FruitsGame":
			if (AnimalIndex <= 0)
				AnimalIndex = games [2].AllAnimalPrefab.Length;
			break;
		case "BekeryGame":
			if (AnimalIndex <= 0)
				AnimalIndex = games [3].AllAnimalPrefab.Length;
			break;
		}
	}

	void Update () 
	{
		if (IsCameraMove==true)
		{
			BgTransform.position = Vector2.MoveTowards (BgTransform.position, CameraPosition, Time.deltaTime*8);
			float dis = Vector2.Distance (BgTransform.position, CameraPosition);
			if (dis == 0)
			{
				IsCameraMove = false;
				AnimalSpawn ();
			}
		}
	}
public	void NextElement()
	{
		UIManager.Instance.blaooonInst();
        //StartCoroutine (NextElementStart());
    }
	IEnumerator NextElementStart()
	{
		yield return new WaitForSeconds (1f);
		
		NextAnimal ();
	}

	void AnimalSpawn()
	{
		switch (selectedGamename) {
		case "AnimalGame":
			CurrnetAnimal = Instantiate ( games[0].AllAnimalPrefab [AnimalIndex], new Vector3 (transform.position.x, transform.position.y, -2), Quaternion.identity) as GameObject;
				//Debug.Log("Current spawn animal = " + games[0].AllAnimalPrefab[AnimalIndex]);

			break; 
		case "VegitableGame":
			CurrnetAnimal = Instantiate ( games[1].AllAnimalPrefab [AnimalIndex], new Vector3 (transform.position.x, transform.position.y, -2), Quaternion.identity) as GameObject;

			break;
		case "FruitsGame":
			CurrnetAnimal = Instantiate ( games[2].AllAnimalPrefab [AnimalIndex], new Vector3 (transform.position.x, transform.position.y, -2), Quaternion.identity) as GameObject;

			break;
		case "BekeryGame":
			CurrnetAnimal = Instantiate ( games[3].AllAnimalPrefab [AnimalIndex], new Vector3 (transform.position.x, transform.position.y, -2), Quaternion.identity) as GameObject;

			break;
		}
		if (CurrnetAnimal != null)
		{
	  	//	CurrnetAnimal.transform.parent = UIManager.Instance.AllModelParent;

		}
	}

	void SelectAnimal()
	{
		if (AnimalIndex == 0)
		{
			previosBTN.SetActive(false);

		}
		if (AnimalIndex % 5 == 0 && AnimalIndex >= 5 && AnimalIndex <= 120)
		{
            UnityAdsManager.Instance.LoadRewardedAd();
        }
           
        if (AnimalIndex % 6 == 0 && AnimalIndex >= 6 && AnimalIndex <= 120)
        {
			
            UnityAdsManager.Instance.ShowRewardedAd();
        }

        string Name;
		switch (selectedGamename) 
		{
		case "AnimalGame":
			//backgound Active
			BackgoundActive (0);



			 Name = FindTypeOFAnimal (games [0].AllAnimalPrefab [AnimalIndex].name);
//			print (Name);
			TypingTextScript.instance.FullText =games[0].AllAnimalPrefab[AnimalIndex].name;
				

			switch (Name) 
			{

			case "HighFlyingAnimal":
//				print ("yha to aaya");
				CameraPosition = new Vector3 (7.273111f, -21.8f,1.41f);
				break;
			case "FlyingAnimal":
				CameraPosition = new Vector3 (7.273111f, -12f,1.41f);
				break;
			case "GroundAnimal":
				CameraPosition = new Vector3 (7.273111f, 1.9f,1.41f);
				break;
			case "Ground_IceAnimal":
				CameraPosition = new Vector3 (7.273111f, 5.5f,1.41f);
				break;
			case "IceAnimal":
				CameraPosition = new Vector3 (7.273111f, 12,1.41f);
				break;
			case "UnderWaterAnimal":
				CameraPosition = new Vector3 (7.273111f, 24.5f,1.41f);
				break;
						// yha krege kaam
			}


			break;
		case "VegitableGame":


			BackgoundActive (1);

			Name = FindTypeOFAnimal (games [1].AllAnimalPrefab [AnimalIndex].name);
			
			TypingTextScript.instance.FullText =games[1].AllAnimalPrefab[AnimalIndex].name;
				
			switch (Name) 
			{
			case "SmallTree":

				CameraPosition = new Vector3 (0, .45f, 14.5f);
				break;
			case "MediumTree":
				CameraPosition = new Vector3 (-23, .45f, 14.5f);
				break;
						// yha kaam krna h
			}

			break;
		case "FruitsGame":

			BackgoundActive (2);

			Name = FindTypeOFAnimal (games [2].AllAnimalPrefab [AnimalIndex].name);
			
			TypingTextScript.instance.FullText =games[2].AllAnimalPrefab[AnimalIndex].name;
			switch (Name) 
			{
			case "SmallTree":

				CameraPosition = new Vector3 (0, .45f, 14.5f);
				break;
			case "MediumTree":
				CameraPosition = new Vector3 (-23, .45f, 14.5f);
				break;
			case "BigTree":
				CameraPosition = new Vector3 (-46, .45f, 14.5f);
				break;
						// yha kaam krna h
			}

			break;

		case "BekeryGame":

			BackgoundActive (3);


			 Name = FindTypeOFAnimal (games [3].AllAnimalPrefab [AnimalIndex].name);

			TypingTextScript.instance.FullText =games[3].AllAnimalPrefab[AnimalIndex].name;
			switch (Name) 
			{
			case "HomeItem":
				
				CameraPosition = new Vector3 (0, .45f, 14.5f);
				break;
			case "CafeItem":
				CameraPosition = new Vector3 (-23, .45f, 14.5f);
				break;
			case "ResturatantItem":
				CameraPosition = new Vector3 (-46, .45f, 14.5f);
				break;
						//yha kaam krna h
			}
			break;

		}
		IsCameraMove = true;
	}


	string FindTypeOFAnimal(string name)
	{
		string MatchName="";

		switch (selectedGamename) 
		{
		case "AnimalGame":
		//high flying animal
			for (int i = 0; i < games [0].ObjectName [0].ObjectOFname.Length; i++) {
				if (games [0].ObjectName [0].ObjectOFname [i] == name) {
					MatchName = "HighFlyingAnimal";
					break;
				}
			}
			if (MatchName != "")
				return MatchName;

		//fling animal
			for (int i = 0; i < games [0].ObjectName [1].ObjectOFname.Length; i++) {
				if (games [0].ObjectName [1].ObjectOFname [i] == name) {
					MatchName = "FlyingAnimal";
					break;
				}
			}

			if (MatchName != "")
				return MatchName;


		//Under_ice animal
			for (int i = 0; i < games [0].ObjectName [3].ObjectOFname.Length; i++) {
//				print (games [0].ObjectName [2].ObjectOFname [i]);
				if (games [0].ObjectName [3].ObjectOFname [i] == name) {
					MatchName = "Ground_IceAnimal";
					break;
				}
			}

			if (MatchName != "")
				return MatchName;

		//ice animal
			for (int i = 0; i < games [0].ObjectName [4].ObjectOFname.Length; i++) {
				if (games [0].ObjectName [4].ObjectOFname [i] == name) {
					MatchName = "IceAnimal";
					break;
				}
			}

			if (MatchName != "")
				return MatchName;


		//uderWater animal
			for (int i = 0; i < games [0].ObjectName [5].ObjectOFname.Length; i++) {
				if (games [0].ObjectName [5].ObjectOFname [i] == name) {
					MatchName = "UnderWaterAnimal";
					break;
				}
			}

			if (MatchName != "")
				return MatchName;


		//Groud animal
			for (int i = 0; i < games [0].ObjectName [2].ObjectOFname.Length; i++) {
				if (games [0].ObjectName [2].ObjectOFname [i] == name) {
					MatchName = "GroundAnimal";
					break;
				}
			}


			break;




		case "VegitableGame":
			//small tree
			//print (name);
			for (int i = 0; i < games [1].ObjectName [0].ObjectOFname.Length; i++) {
				//print (games [1].ObjectName [0].ObjectOFname [i]);
				if (games [1].ObjectName [0].ObjectOFname [i] == name) {
						if (i  == 4)
						{
							
						}
					MatchName = "SmallTree";
					break;
				}
			}
			if (MatchName != "")
				return MatchName;

			//B Tree
			for (int i = 0; i < games [1].ObjectName [1].ObjectOFname.Length; i++) {
				if (games [1].ObjectName [1].ObjectOFname [i] == name) {
						if (i == 3)
						{
							
						}
					MatchName = "MediumTree";
					break;
				}
			}


			if (MatchName != "")
				return MatchName;

			break;

		case "FruitsGame":
			//Small tree
			//print (name);
			for (int i = 0; i < games [2].ObjectName [0].ObjectOFname.Length; i++) {
				if (games [2].ObjectName [0].ObjectOFname [i] == name) {
					MatchName = "SmallTree";
					break;
				}
			}
			if (MatchName != "")
				return MatchName;

			//fling animal
			for (int i = 0; i < games [2].ObjectName [1].ObjectOFname.Length; i++) {
				if (games [2].ObjectName [1].ObjectOFname [i] == name) {
					MatchName = "MediumTree";
					break;
				}
			}

			if (MatchName != "")
				return MatchName;


			//Under_ice animal
			for (int i = 0; i < games [2].ObjectName [2].ObjectOFname.Length; i++) {
				//				print (games [0].ObjectName [2].ObjectOFname [i]);
				if (games [2].ObjectName [2].ObjectOFname [i] == name) {
					MatchName = "BigTree";
					break;
				}
			}

			if (MatchName != "")
				return MatchName;




			break;









		case "BekeryGame":
			//high flying animal
			//print (name);
			for (int i = 0; i < games [3].ObjectName [0].ObjectOFname.Length; i++) {
				if (games [3].ObjectName [0].ObjectOFname [i] == name) {
					MatchName = "HomeItem";
					break;
				}
			}
			if (MatchName != "")
				return MatchName;

			//fling animal
			for (int i = 0; i < games [3].ObjectName [1].ObjectOFname.Length; i++) {
				if (games [3].ObjectName [1].ObjectOFname [i] == name) {
					MatchName = "CafeItem";
					break;
				}
			}

			if (MatchName != "")
				return MatchName;


			//Under_ice animal
			for (int i = 0; i < games [3].ObjectName [2].ObjectOFname.Length; i++) {
				//				print (games [0].ObjectName [2].ObjectOFname [i]);
				if (games [3].ObjectName [2].ObjectOFname [i] == name) {
					MatchName = "ResturatantItem";
					break;
				}
			}

			if (MatchName != "")
				return MatchName;




			break;

		}
//		print (MatchName);
			return MatchName;
//		}

//		if (MatchName != "")  return MatchName;
	}


	void BackgoundActive(int value)
	{
		for(int i =0 ;i< games.Length;i++)
		{
			games[i].BG.SetActive(false);
			if(value==i)
			{
			
				games[i].BG.SetActive(true);
				BgTransform = games [i].BG.transform;
			}
		}
	}

}
