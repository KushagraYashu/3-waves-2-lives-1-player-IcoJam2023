using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float recoilForce;
    public GameObject bulletPrefab;

    public Transform white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FireFxn();
            
        }
    }

    void FireFxn()
    {
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().Fire();
        Debug.Log("Fire");
        Instantiate(bulletPrefab, this.transform.position, white.rotation);
        this.gameObject.GetComponentInParent<Rigidbody2D>().AddRelativeForce(new Vector2(-recoilForce, 0), ForceMode2D.Impulse);
        this.gameObject.GetComponentInChildren<ParticleSystem>().Play();
    }
}
