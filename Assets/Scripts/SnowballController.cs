using UnityEngine;

public class SnowballController : BulletController
{
    public override void HandleHit(GameObject hitting)
    {
        if (!hitting.CompareTag("Enemy") && !hitting.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}