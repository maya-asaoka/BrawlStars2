using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In-game enemy that follows and shoots at player

public class EnemyController : MonoBehaviour {

    public GameObject player;
    public GameObject coinPrefab;
    public GameObject enemyBulletPrefab;

    public int hp;

    // enemy will stay playerRadius away from player
    public float playerRadius;
    public float fireRate;
    public float speed;
    public float turnSpeed;

    private Rigidbody rb;

    // positions coins and bullets slightly up off the ground
    private Vector3 raiseCoin = new Vector3(0, 0.7f, 0);
    private Vector3 raiseBullet = new Vector3(0, 1f, 0);


	void Start () 
    {
        rb = GetComponent<Rigidbody> ();
        player = GameController.instance.player;
        InvokeRepeating("FireAtPlayer", 2.0f, fireRate);
	}

    void FireAtPlayer()
    {
        Instantiate(enemyBulletPrefab, transform.position + raiseBullet, transform.rotation);
    }


    // rotate towards player then move, keep out of player radius
    private void FixedUpdate()
    {
        Vector3 playerPosition = player.gameObject.transform.position;

        Vector3 towardsPlayer = playerPosition - transform.position;
        Vector3 rotationDirection = Vector3.RotateTowards(transform.forward, towardsPlayer, turnSpeed * Time.deltaTime, 0.0f);
        rb.MoveRotation(Quaternion.LookRotation(rotationDirection));

        if (Vector3.Distance(transform.position, playerPosition) > playerRadius)
        {
            Vector3 moveTowardsPlayer = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
            rb.MovePosition(moveTowardsPlayer);
        }
    }

    // killed enemies leave a coin in their place
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            hp--;
            if (hp == 0)
            {
                Instantiate(coinPrefab, transform.position + raiseCoin, Quaternion.identity);
                EnemyRespawner.instance.RespawnEnemy();
                Destroy(this.gameObject);
            }
        }
    }

}
