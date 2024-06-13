using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelDragBehavior : MonoBehaviour
{
	public static GameObject IBeginDragged;
	Vector3 startPosition;
	Transform startPerent;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	Vector3 offset;
	
	private float forceConstant = 150 ;
	private bool returning = false;
	private float precision = 0.1f;
	Vector3 scaleONE;
    
	public static PanelDragBehavior instance;

    private void Awake()
    {
		instance = this;
    }
    void Start()
	{
		scaleONE = transform.position;
        gameObject.layer = 6;
	}

	public void OnMouseDown()
	{
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		IBeginDragged = gameObject;
		offset = transform.localPosition;// - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
		
		indexPart = int.Parse (gameObject.name);
		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 3;
	}
	int indexPart;
	
	public void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		curPosition.z = 0;
		transform.position = curPosition;
		
		float f = Vector2.Distance (gameObject.transform.position, AnimalPartScript.Instance.partlist [indexPart].transform.position);
      
      //  CameraContoller.CameraContollerInstance.Buttonofff();
       


        if (f<.5f) 
		{		 
			gameObject.SetActive (false);
		         
            AnimalPartScript.Instance.partlist [indexPart].gameObject.SetActive(true);
			//Debug.Log("Rahul" + AnimalPartScript.Instance.partlist[indexPart].gameObject.name);
			AnimalPartScript.Instance.PartIndex++;
						
            Vector3 posi = new Vector3(transform.position.x, transform.position.y, -218f);	
            Instantiate(UIManager.Instance.Particle_, posi, Quaternion.identity);
		

			if ((AnimalPartScript.Instance.partlist.Count) == AnimalPartScript.Instance.PartIndex) {
				//print(AnimalPartScript.Instance.partlist + " part name " );
				
				SoundManager.instance.levelcompletesound ();
               
                TypingTextScript.instance.showtext ();
                
                CameraContoller.CameraContollerInstance.nextWait ();

				UIManager.Instance.ObjectBg_panal.SetActive (false);
				//print(AnimalPartScript.Instance.PartIndex + " AKshay   0009");
            }
           
            else
			{       

                SoundManager.instance.partAttachsound ();			
			}
		}
	}

	public void OnMouseUp()
	{
		IBeginDragged = null;
		returning = true;
		SoundManager.instance.springaudio();
		print("adfodfah");
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		//print(gameObject.name);
	}
	bool flag;
	void Update()
	{
		if (returning) {
			GetComponent<Rigidbody2D> ().AddForce (forceConstant * (scaleONE - transform.position));
			GetComponent<Rigidbody2D> ().velocity *= 0.9f;
			//print (gameObject.name);
			
			if (GetComponent<Rigidbody2D> ().velocity.magnitude < precision &&
			    Vector3.Distance (transform.position, scaleONE) < precision) {
				//print(gameObject.transform.position + "position no 2");
					
				GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		
				returning = false;
			}
		}
	}
}
