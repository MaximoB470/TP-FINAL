using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public int Life;
    private Transform player;
    public int damageAmount = 1;
    private HealthHandler healthHandler;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = ServiceLocator.Instance.GetService<GameManager>();
        var playerController = ServiceLocator.Instance.GetService<PlayerController>();
        if (playerController != null)
        {
            player = playerController.transform;
        }
        healthHandler = gameObject.AddComponent<HealthHandler>();
        healthHandler.maxHp = 1;
        healthHandler.Awake();

    }
    private void Update()
    {
        MoveTowardsPlayer();

        if (healthHandler.Life <= 0)
        {
           gameManager.EnemyDefeated();  
           Destroy(gameObject);  
        }
    }
    private void MoveTowardsPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            var playerHealth = collision.gameObject.GetComponent<HealthHandler>();
            if (playerHealth != null)
            {
                playerHealth.GetDamage(damageAmount);
                var audioService = ServiceLocator.Instance.GetService<IAudioService>();
                if (audioService != null)
                {
                    audioService.HitSound();
                }
            }
             healthHandler.Life = 0;
        }
    }
}