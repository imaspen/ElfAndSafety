using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	private PlayerController _player;
	private GameController _game;
	private Text _hp;
	private Text _score;

	private void Start () {
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
		_game = GameObject.Find("Game Controller").GetComponent<GameController>();
		_hp = GameObject.Find("HP Counter").GetComponent<Text>();
		_score = GameObject.Find("Score Counter").GetComponent<Text>();
	}
	
	// Update is called once per frame
	private void Update ()
	{
		_hp.text = "HP: " + _player.HP + "/" + _player.MaxHp;
		_score.text = "Score: " + _game.Score;
	}
}
