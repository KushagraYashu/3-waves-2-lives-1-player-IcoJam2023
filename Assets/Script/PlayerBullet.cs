using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletForceMag;
    public float timer;
    float curTimer;

    // Start is called before the first frame update
    void Start()
    {
        curTimer = timer;
        this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2 (bulletForceMag, 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(curTimer > 0.1)
        {
            curTimer -= Time.deltaTime;
        }
        else
        {
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().Hit();
            collision.gameObject.GetComponent<Enemy>().DecreaseHealth(10);
            Destroy(this.gameObject);
        }
    }

}
