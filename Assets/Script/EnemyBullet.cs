using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    public Transform playerSprite;
    public Vector2 target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(playerSprite.position.x, playerSprite.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSprite != null) {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().Hurt();
            collision.gameObject.GetComponent<PlayerMovement>().DecreaseHealth(damage);
            Destroy(this.gameObject);
        }
    }

}
