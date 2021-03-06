﻿using UnityEngine;

public class gameOver : MonoBehaviour {
	scoreManager score;
	public bool isGameOver, isGoMenu;

	public Light heroLight;
	public Light enemyLight;
	public float durationLightOff;	//durasi light meredup

	public sceneManager scene;

	void Error () {
		if (!scene) Debug.LogError ("scene is null (gameOver)");
		if (!heroLight) Debug.LogError ("heroLight is null (gameOver)");
		if (!enemyLight) Debug.LogError ("enemyLight is null (gameOver)");
	}

	void Start () {
		Error ();

		score = GetComponent<scoreManager> ();
		if (!score) Debug.LogError ("score (scoreManager) is null (gameOver)");

		isGameOver 	= false;
		isGoMenu	= false;
	}

	void Update () {
		if (isGameOver) {
			Time.timeScale = 0;
			HeroLightOff ();
			EnemyLightOff ();
		}
	}

	void HeroLightOff () {
		if (heroLight && heroLight.intensity > 0)
			heroLight.intensity -= durationLightOff + Time.deltaTime;
		else if (!isGoMenu) {
			scene.SceneName ("Menu");
			scene.WaitTime (3f);
			isGoMenu = true;

			if (score) score.SaveScore ();
		}
	}

	void EnemyLightOff () {
		if (enemyLight && enemyLight.intensity > 0)
			enemyLight.intensity -= durationLightOff + Time.deltaTime;
	}
}