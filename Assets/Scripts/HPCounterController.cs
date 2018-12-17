using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPCounterController : MonoBehaviour
{
	private PlayerController _player;
	private Text _text;
	
	void Start () {
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
		_text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_text.text = "HP: " + _player.HP + "/" + _player.MaxHp;
	}
}
