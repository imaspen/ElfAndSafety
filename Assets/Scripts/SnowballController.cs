using UnityEngine;

public class SnowballController : BulletController
{
    public override void HandleHit(Collider2D other)
    {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
    }
}