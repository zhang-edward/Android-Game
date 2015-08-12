﻿using UnityEngine;
using System.Collections;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


/// <summary>
/// Manage Scorekeeping and all Google Play Services
/// </summary>
public class ScoreManager : MonoBehaviour {

	public int lastScore;
	public int highScore;

	public int gamesPlayed;

	public static ScoreManager instance;

	void Awake()
	{
		// Make this a singleton
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		// get the high score from the playerPrefs
		highScore = PlayerPrefs.GetInt("High Score");
		gamesPlayed = PlayerPrefs.GetInt ("Games Played");

		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			.Build();
		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform

		PlayGamesPlatform.Activate();
	}
	
	public void UpdateScore(int score)
	{
		lastScore = score;
		if (lastScore > highScore)
			highScore = lastScore;

		// store the high score locally
		PlayerPrefs.SetInt ("High Score", highScore);
	}

	public void GPGReportScore()
	{
		Social.ReportScore(highScore, "CgkItczL6uMHEAIQBw", (bool success) => {
		});
	}
}