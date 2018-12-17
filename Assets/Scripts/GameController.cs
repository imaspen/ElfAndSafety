using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	private float _lastSpawned;
	
	[SerializeField] private float _spawnDelay = 2.0f;
	[SerializeField] private GameObject _enemy;

	public int Score { get; set; }

	private void Update()
	{
		if (_lastSpawned <= 0)
		{
			if (Random.Range(0, 100) != 69) return;
			Instantiate(_enemy);
			_lastSpawned = _spawnDelay;
		}
		else
		{
			_lastSpawned -= Time.deltaTime;
		}
	}
}
