using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	public static UIManager Instance;

	[Header("Game Ui and Panal")]


	public GameObject[] AllGamepanal;

	public GameObject[] GameMenu;

	public GameObject GameSelection;
	public GameObject SettingPanal;
	public GameObject BakerySet_;
	public GameObject vegetableSet;
	public GameObject fruitSET;
	public GameObject Particle_;

	public GameObject EXITpanel;

	public Transform[] AllModelParent;
	public GameObject ObjectBg_panal;

	public CameraContoller cameracontroller;
	public Vector2[] objLIST;
	bool Issetting;
	public GameObject panelBlack;
    public GameObject[] balloons;
	public  int BalloonRemaining;
  //  public Vector3 spawnPOS;
    //public GameObject gameplayExit;
    //public int[] List;
    void Awake()
	{
		Instance = this;
	}
    private void Start()
    {
		BalloonRemaining = balloons.Length;
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape) )  
            {

				if (AllGamepanal[1].activeSelf)
				{
					SceneManager.LoadScene(0);
					
				}
				else if(AllGamepanal[0].activeSelf)
				{
                    EXITpanel.SetActive(true);
                }

                return;
            }
        }
        if (gamefinished)
		{

		}
        /*if (BalloonRemaining == 0)
		{
		
			print(balloons[BalloonRemaining]);
        }*/
    }
	public void BalloonDestroyed()
	{
        BalloonRemaining--;
		
		if (BalloonRemaining <=0)
		{
			Debug.Log("balloon");
            BalloonRemaining = balloons.Length;
            CameraContoller.CameraContollerInstance.buttonNXT.SetActive(true);
        }
    }

	

    public void ButtonEvent(string msg)
	{
		ButtonSound();
		switch (msg)
		{
			case "PlayButt":
				setActivePanal(1);
				cameracontroller.enabled = true;

				break;

			case "OkGameButt":
				setActivePanal(1);

				cameracontroller.enabled = true;
				cameracontroller.Start();
				break;


			case "AnimalGameButt":
				setActiveMenu(0);
				cameracontroller.selectedGamename = "AnimalGame";

				break;
			case "VegitableGameButt":
				setActiveMenu(1);
				cameracontroller.selectedGamename = "VegitableGame";


				break;
			case "FruitGameButt":
				setActiveMenu(2);
				cameracontroller.selectedGamename = "FruitsGame";

				break;
			case "BakeGameButt":
				setActiveMenu(3);

				cameracontroller.selectedGamename = "BekeryGame";

				break;
			case "GameMenuCloseButt":
				GameSelection.SetActive(false);
				break;
			case "Gamemenuselection":
				GameSelection.SetActive(true);
				break;


			case "SettingButt":

				if (!SettingPanal.activeSelf)
				{
					SettingPanal.SetActive(true);
					SettingPanal.GetComponent<Animator>().Play("settingMenu");
				}
				else
				{
					SettingPanal.GetComponent<Animator>().Play("settingreverse");
					StartCoroutine("waitsometime");
				}
				break;

			case "ExitButt":
				EXITpanel.SetActive(true);
				break;
		}
	}
    //public int randomNUM;
    public bool gamefinished;
    public void blaooonInst()
	{
        gamefinished = true;
        foreach (GameObject balloonPrefab in balloons)
		{
            float randomY = UnityEngine.Random.Range(-10f, -13f);
            float randomX = UnityEngine.Random.Range(-10f, 10f);
            Vector3 vector = new Vector3(randomX, randomY, transform.position.z);

            Instantiate(balloonPrefab, vector, Quaternion.identity);
          //  print(" our X position is " + vector);
        }
		
		
    }

	IEnumerator waitsometime()
	{
		yield return new WaitForSeconds(1f);
		SettingPanal.SetActive(false);
	}

	void setActivePanal(int indx)
	{
		for (int i = 0; i < AllGamepanal.Length; i++)
		{
			AllGamepanal[i].SetActive(false);
			if (i == indx)
				AllGamepanal[i].SetActive(true);
		}
	}
	void setActiveMenu(int indx)
	{

		for (int i = 0; i < GameMenu.Length; i++)
		{
			GameMenu[i].transform.GetChild(1).gameObject.SetActive(false);
			if (i == indx)
			{
				GameMenu[i].transform.GetChild(1).gameObject.SetActive(true);
			}
		}
	}

	public void PANELBLACK()
	{
		panelBlack.SetActive(true);
	}
	public void PANELWHITE()
	{
		panelBlack.SetActive(false);
	}
	public void SetImage()
	{
		BakerySet_.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

		vegetableSet.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

		fruitSET.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
	}

	public void ButtonSound()
	{
		GetComponent<AudioSource>().Play();
	}

	public void leavethegame()
	{
		ButtonSound();
		Application.Quit();
		
    }
    public void BacktoGame()
    {
        
            ButtonSound();
            EXITpanel.SetActive(false);

    }
	
}
