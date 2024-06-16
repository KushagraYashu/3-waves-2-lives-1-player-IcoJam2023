using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int maxLives;
    public int livesLeft;

    public float speed;
    public float rotateSpeed;
    float verticalInput;
    float horizontalInput;
    float rotateDir;

    public float maxHealth;
    public float curHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        livesLeft = maxLives;
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        verticalInput = Input.GetAxis("Vertical") * speed;

        if (Input.GetKey(KeyCode.E))
        {
            rotateDir = 1;
        }else if (Input.GetKey(KeyCode.Q))
        {
            rotateDir = -1;
        }
        else
        {
            rotateDir = 0;
            this.gameObject.GetComponent<Rigidbody2D>().AddTorque(0);
        }

        if (Mathf.Abs(verticalInput) >= 0.3 || Mathf.Abs(horizontalInput) >= 0.3)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalInput, verticalInput));

        }
        else if (Mathf.Abs(verticalInput) < 0.3 && Mathf.Abs(horizontalInput) < 0.3)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalInput / 5, verticalInput / 5));

        }

        this.transform.Rotate(new Vector3(0, 0, rotateDir * rotateSpeed / 10));


        if(curHealth <= 0 && livesLeft == 0)
        {
            curHealth = 0;
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayerDead();
            UIManager.DeadScreenDisp();
            Destroy(this.gameObject);
        }
        
        if(curHealth <=0 && livesLeft > 0)
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().LifeUsed();
            Debug.Log("Use Life");
            curHealth = maxHealth;
            livesLeft--;
        }


    }

    public void DecreaseHealth(int damage)
    {
        curHealth -= damage;
    }

}
