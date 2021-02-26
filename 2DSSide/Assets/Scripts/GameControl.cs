using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using System.Collections.Generic;

public class GameControl : MonoBehaviour
{
	[Serializable]
	public class ChallengeLevel
	{
		public float timeTillChange;
		public float speed;
		public float columnSpawnRate;
	}


	public static GameControl instance;         //A reference to our game control script so we can access it statically.
	public Text scoreText;                      //A reference to the UI text component that displays the player's score.

	public Text endScore;
	public Text highscoreText;

	public GameObject gameOvertext;             //A reference to the object that displays the text which appears when the player dies.

	private int score = 0; //The player's score.
	private int highscore; //highscore
	public bool gameOver = false;               //Is the game over?
	public float scrollSpeed = 1.5f;

	public bool scrollStarted = false;

	public int easySpeed, hardSpeed;

	private float timeRemaining;
	private int challengeLevel = 0;
	private bool stopSpeedup = false;
	private ColumnPool cp;

	private AccountManager accountMan;          //Holds Account Information

	private DifficultySingleton difficulty;

	void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if (instance != this)
			//...destroy this one because it is a duplicate.
			Destroy(gameObject);

		if (PlayerPrefs.HasKey("Highscore"))
		{
			//PlayerPrefs.SetInt("Highscore", 0);
			highscore = PlayerPrefs.GetInt("Highscore");
		}
		
	}

	private void Start()
	{
		//Find Account Manager
		//accountMan = GameObject.FindGameObjectWithTag("AccountManager").GetComponent<AccountManager>();

		accountMan = FindObjectOfType<AccountManager>();

		difficulty = FindObjectOfType<DifficultySingleton>();

		if (difficulty != null && difficulty.CheckIsHard())
		{
			Debug.Log("Hard");
			scrollSpeed = hardSpeed;
		}
		else
		{
			Debug.Log("Easy");
			scrollSpeed = easySpeed;
		}

		Debug.Log("speed: " + scrollSpeed);
		cp = gameObject.GetComponent<ColumnPool>();


	}

	void Update()
	{
		//If the game is over and the player has pressed some input...
		if (gameOver && Input.GetMouseButtonDown(0))
		{
			//gameOvertext.SetActive(false);
			//...reload the current scene.
			//SceneManager.LoadScene(1);
		}

		/*if (!gameOver && scrollStarted)
		{
			//Debug.Log("Started");
			if (difficulty != null && challengeLevel < difficulty.Count)
			{
				

				if(timeRemaining > 0)
				{
					timeRemaining -= Time.deltaTime;
				}
				else
				{
					scrollSpeed += Time.deltaTime;

					if(scrollSpeed >= difficulty[challengeLevel].speed)
					{
						scrollSpeed = difficulty[challengeLevel].speed;
						cp.spawnRate = difficulty[challengeLevel].columnSpawnRate;

						challengeLevel++;
						if (challengeLevel < difficulty.Count)
							timeRemaining = difficulty[challengeLevel].timeTillChange;
					}
				}
			}*/

			//Check index for the list of ChallengeLevels
			//Set a variable equal to the current time
			//when the time is >= the initial time + the timeTillChange amount, begin lerping to the new speed and set the spawncolumn time = to the number in ChallengeLevels
			//After lerping to new speed, set time variable to current time and repeat the process.
		//}
	}

	public void BirdScored()
	{
		//The bird can't score if the game is over.
		if (gameOver)
			return;
		//If the game is not over, increase the score...
		score++;
		//...and adjust the score text.
		scoreText.text = ": " + score.ToString();

		updateHighscore();
	}

	private void updateHighscore()
	{
		if(score > highscore)
		{
			highscore = score;
			PlayerPrefs.SetInt("Highscore", highscore);
		}
		
	}

	public void BirdDied()
	{
		//Activate the game over text.
		gameOvertext.SetActive(true);

		//set score text
		endScore.text = "             :" + score.ToString();
		highscoreText.text = "             :" + highscore.ToString();

		//Add coins to Account

		//This line was causing scroll error
		if(accountMan != null)
		{
			accountMan.AddCoins(score);
		}
		

		//Set the game to be over.
		gameOver = true;
	}

	public void StartScroll()
	{
		Debug.Log("Started Set");
		scrollStarted = true;
		//Set start time initially
		
	}
}
