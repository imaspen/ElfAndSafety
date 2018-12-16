using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	[SerializeField] private float _speed;
	
	private void Start()
	{
		GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector3(0, _speed);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		HandleHit(other.gameObject);
	}

	public virtual void HandleHit(GameObject hitting)
	{
		Destroy(gameObject);
	}
}
