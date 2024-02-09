using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_manager : MonoBehaviour {

	[SerializeField]GameObject mainMenuPanelObject;
	bool activeStatus = false;

	// Use this for initialization
	void Start () {
		mainMenuPanelObject.SetActive(activeStatus);
	}
	
	// Update is called once per frame
	void Update () {
		checkUI();
	}

	void checkUI() {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(activeStatus == true){
				activeStatus = false;
			}else{
				activeStatus = true;
			}
			mainMenuPanelObject.SetActive(activeStatus);
		}
	}

	public void restartGame() {
		SceneManager.LoadScene("game");
	}

	public void exitGame() {
		Application.Quit();
	}

	public void displayMainMenu() {
		activeStatus = true;
		mainMenuPanelObject.SetActive(activeStatus);
	}
}
