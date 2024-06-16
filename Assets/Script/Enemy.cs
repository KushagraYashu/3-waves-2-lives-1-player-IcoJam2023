using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;

    public Transform playerSprite;
    public Transform center;
    public GameObject enemyBullet;
    public float speed;
    public float minDist;
    public float timeBtwShots;
    float curTimeBtwShot;

    public float maxHealth;
    float curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        curTimeBtwShot = timeBtwShots;
        playerSprite = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, playerSprite.position) > minDist)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, playerSprite.position, speed * Time.deltaTime);
        }else if(Vector2.Distance(transform.position,playerSprite.position) < minDist)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, playerSprite.position, -speed * Time.deltaTime);
        }

        if(curTimeBtwShot <= 0)
        {
            FireFxn();
            curTimeBtwShot = timeBtwShots;
        }
        else
        {
            curTimeBtwShot -= Time.deltaTime;
        }

        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    void FireFxn()
    {
        if(playerSprite != null)
        {
            var a = Instantiate(enemyBullet, this.transform.position, center.rotation);
            a.GetComponent<EnemyBullet>().damage = damage;
        }
    }

    public void DecreaseHealth(int damage)
    {
        curHealth -= damage;
    }

}
