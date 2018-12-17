using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : BulletController
{
    protected override void HandleHit(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.CompareTag("Wall"))
            Destroy(gameObject);
    }
}