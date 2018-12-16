using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	private float _lastSpawned = 0.0f;
	private float _spawnDelay = 2.0f;
	[SerializeField] private GameObject _enemy;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_lastSpawned <= 0)
		{
			if (Random.Range(0, 100) == 69)
			{
				Instantiate(_enemy);
				_lastSpawned = _spawnDelay;
			}
		}
		else
		{
			_lastSpawned -= Time.deltaTime;
		}
	}
}
