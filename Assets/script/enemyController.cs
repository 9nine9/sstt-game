﻿using UnityEngine;

public class enemyController : MonoBehaviour {
	public GameObject map;
	tileMap node;
	scoreManager score;
	public float speed;
	public float[] speedRandom;
	public bool isSpeedUltimate;
	public int chanceUltimmate = 25;
	public float speedUltimate;
	public int blueScoreForSpeedUtimate;
	public float durationSpeed;

	void Error () {
		//error
		if (!map) Debug.LogError ("map is null (enemyController)");
	}

	void Start () {
		Error ();
		if (map) {
			node = map.GetComponent<tileMap> ();
			if (!node) Debug.LogError ("node (map) is null (enemyController)");

			score = map.GetComponent<scoreManager> ();
			if (!node) Debug.LogError ("score (map) is null (enemyController)");
			else InvokeRepeating ("ChangeSpeed", durationSpeed, durationSpeed);
		}
	}

	void Update () {
		if (node) {
			ChangeNode ();
		}
	}

	//node yang ditempati enemy
	void ChangeNode () {
		int x = (int) Mathf.Round (transform.position.x / node.tileSize);
		int y = (int) Mathf.Round (transform.position.y / node.tileSize);

		//jika node tidak melewati batas map, maka update
		if (x >= 0 && x < node.mapWidth && y >= 0 && y < node.mapHeight) {
			node.enemy.x = x;
			node.enemy.y = y;
		}
		//print (node.enemy.x+","+node.enemy.y);
	}

	void ChangeSpeed () {
		int newSpeed = Random.Range (0, speedRandom.Length - 1);
		speed = speedRandom [newSpeed];

		if (isSpeedUltimate) {
			int chance = Random.Range (0, 100); //25% from 100%
			if (chance <= chanceUltimmate) {
				speed = speedUltimate;
			}
		}
		else {
			if (score.blueSoulScore >= blueScoreForSpeedUtimate)
				isSpeedUltimate = true;
		}
	}
}
