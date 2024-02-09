using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour {

	[SerializeField] string[] rock_paper_scissors = {"Rock", "Paper", "Scissors"};
	[SerializeField] Text gameText;
	[SerializeField] Text playerScoreText;
	[SerializeField] Text enemyScoreText;
	player rock_paper_scissors_player;
	opponent enemy;
	bool isPlaying = false;
	ui_manager ui;
	string winner = "";

	// Use this for initialization
	void Start () {
		Debug.Log("rock_paper_scissors: " + rock_paper_scissors);
		rock_paper_scissors_player = GameObject.Find("Player").GetComponent<player>();
		enemy = GameObject.Find("Opponent").GetComponent<opponent>();
		ui = GameObject.Find("UICanvas").GetComponent<ui_manager>();
		newGame();
		StartCoroutine(playGame());
	}
	
	// Update is called once per frame
	void Update () {
	}

	void newGame(){
		Debug.Log("newGame");
		isPlaying = true;
	}

	void checkGame(){
		Debug.Log("checkGame");
		int playerChoice = rock_paper_scissors_player.getPlayerChoice();
		Debug.Log("playerChoice: " + playerChoice);
		if(playerChoice != -1){
			rock_paper_scissors_player.setPlayerChoiceText(rock_paper_scissors[playerChoice]);
		}

		int enemyChoice = enemy.getOpponentChoice();
		Debug.Log("enemyChoice: " + enemyChoice);
		if(enemyChoice != -1){
			enemy.setOpponentChoiceText(rock_paper_scissors[enemyChoice]);
		}

		switch(playerChoice){
			case 0:
				if(enemyChoice == 0){
					winner = "";
				}else if(enemyChoice == 1){
					winner = "Opponent";
				}else if(enemyChoice == 2){
					winner = "Player";
				}
				break;
			case 1:
				if(enemyChoice == 0){
					winner = "Player";
				}else if(enemyChoice == 1){
					winner = "";
				}else if(enemyChoice == 2){
					winner = "Opponent";
				}
				break;
			case 2:
				if(enemyChoice == 0){
					winner = "Opponent";
				}else if(enemyChoice == 1){
					winner = "Player";
				}else if(enemyChoice == 2){
					winner = "";
				}
				break;
			default:
				winner = "None";
				break;
		}
	}

	void determineWinner(){
		if(winner.Length > 0 && winner != "None"){
			setGameText(winner + " Wins!");
		}else if(winner.Length == 0){
			setGameText("Draw!");
		}else if(winner == "None"){
			setGameText("No Choice!");
		}
	}
	
	void resetGame(){
		Debug.Log("resetGame");
		isPlaying = false;
	}

	public void setGameText(string game_text){
		gameText.text = game_text;
	}

	public void clearGameText(){
		gameText.text = "";
	}

	public void setPlayerScoreText(string player_score_text){
		playerScoreText.text = player_score_text;
	}

	public void setEnemyScoreText(string enemy_score_text){
		enemyScoreText.text = enemy_score_text;
	}

	IEnumerator playGame(){
		Debug.Log("playGame");
		setGameText("Start");
		yield return new WaitForSeconds(0.2f);
		if(isPlaying == true){
			for(int i=0; i<3; i=i+1){
				yield return new WaitForSeconds(0.2f);
				switch(i){
					case 0:
						setGameText("Rock");
						break;
					case 1:
						setGameText("Paper");
						break;
					case 2:
						setGameText("Scissors");
						break;
					default:
						clearGameText();
						break;
				}
			}
			yield return new WaitForSeconds(0.2f);
			clearGameText();
			enemy.opponentPlayGame();
			yield return new WaitForSeconds(1.0f);
			checkGame();
			determineWinner();
			resetGame();
			yield return new WaitForSeconds(1.0f);
			clearGameText();
			ui.displayMainMenu();
		}else{
			newGame();
		}
	}
}
