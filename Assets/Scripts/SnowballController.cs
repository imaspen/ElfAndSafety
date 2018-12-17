using UnityEngine;

public class SnowballController : BulletController
{
    protected override void HandleHit(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
    }
}