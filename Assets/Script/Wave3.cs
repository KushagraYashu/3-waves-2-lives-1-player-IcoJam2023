using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3 : MonoBehaviour
{

    public GameObject enePrefab;
    public List<Transform> spawnPt;
    public int damage;
    public float fireRate;
    public float speed;
    public float maxHealth;

    public GameObject ene1;
    public GameObject ene2;
    public GameObject ene3;
    public GameObject ene4;

    public bool waveComplete = false;
    public bool waveInitiated = false;

    public bool delay = false;

    // Start is called before the first frame update
    void Start()
    {
        waveComplete = false;
        waveInitiated = false;
        enePrefab = this.gameObject.GetComponentInParent<WaveManager>().enePrefab;
        spawnPt = this.gameObject.GetComponentInParent<WaveManager>().spawnPt;
        damage = this.gameObject.GetComponentInParent<WaveManager>().wav3Damage;
        fireRate = this.gameObject.GetComponentInParent<WaveManager>().wav3FireRate;
        speed = this.gameObject.GetComponentInParent<WaveManager>().wav3Speed;
        maxHealth = this.gameObject.GetComponentInParent<WaveManager>().wav3Health;
        CallCoroutine();
    }

    // Update is called once per frame
    void Update()
    {
        if (ene1 == null && ene2 == null && ene3 == null && ene4 == null && waveInitiated && !waveComplete)
        {
            waveComplete = true;
            

        }
    }

    public void CallCoroutine()
    {
        StartCoroutine(InsEnemies());
    }

    public IEnumerator InsEnemies()
    {
        delay = true;
        yield return new WaitForSeconds(3f);
        waveInitiated = true;
        ene1 = Instantiate(enePrefab, spawnPt[0].position, Quaternion.identity);
        ene1.GetComponent<Enemy>().damage = damage;
        ene1.GetComponent<Enemy>().timeBtwShots = fireRate;
        ene1.GetComponent<Enemy>().speed = speed;
        ene1.GetComponent<Enemy>().maxHealth = maxHealth;
        yield return new WaitForSeconds(2f);
        ene2 = Instantiate(enePrefab, spawnPt[1].position, Quaternion.identity);
        ene2.GetComponent<Enemy>().damage = damage;
        ene2.GetComponent<Enemy>().timeBtwShots = fireRate;
        ene2.GetComponent<Enemy>().speed = speed;
        ene2.GetComponent<Enemy>().maxHealth = maxHealth;
        yield return new WaitForSeconds(2f);
        ene3 = Instantiate(enePrefab, spawnPt[2].position, Quaternion.identity);
        ene3.GetComponent<Enemy>().damage = damage;
        ene3.GetComponent<Enemy>().timeBtwShots = fireRate;
        ene3.GetComponent<Enemy>().speed = speed;
        ene3.GetComponent<Enemy>().maxHealth = maxHealth;
        yield return new WaitForSeconds(2f);
        ene4 = Instantiate(enePrefab, spawnPt[3].position, Quaternion.identity);
        ene4.GetComponent<Enemy>().damage = damage;
        ene4.GetComponent<Enemy>().timeBtwShots = fireRate;
        ene4.GetComponent<Enemy>().speed = speed;
        ene4.GetComponent<Enemy>().maxHealth = maxHealth;
    }

}
