using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 1;
    private BulletPool bulletPool;
    public void SetPool(BulletPool pool)
    {
        bulletPool = pool; 
    }
    public void Initialize(Transform firePoint)
    {
        transform.position = firePoint.position;
        transform.rotation = firePoint.rotation;
        rb.velocity = firePoint.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemies"))
        {
            var enemyHealth = collision.GetComponent<HealthHandler>();
            if (enemyHealth != null)
            {
                enemyHealth.GetDamage(damage);
            }

            var audioService = ServiceLocator.Instance.GetService<IAudioService>();
            if (audioService != null)
            {
                audioService.HitSound();
            }
            bulletPool.ReturnToPool(this);
        }
        if (collision.CompareTag("Walls"))
        {
            bulletPool.ReturnToPool(this);
        }
    }
}