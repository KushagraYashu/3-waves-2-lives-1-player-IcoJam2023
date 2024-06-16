using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enePrefab;

    public List<Transform> spawnPt;

    public int wav1Damage;
    public int wav2Damage;
    public int wav3Damage;

    public float wav1FireRate;
    public float wav2FireRate;
    public float wav3FireRate;

    public float wav1Speed;
    public float wav2Speed;
    public float wav3Speed;

    public float wav1Health;
    public float wav2Health;
    public float wav3Health;

    public bool wav1Initiated = false;
    public bool wav2Initiated = false;
    public bool wav3Initiated = false;

    public GameObject wav1;
    public GameObject wav2;
    public GameObject wav3;

    public GameObject wav1Panel;
    public GameObject wav2Panel;
    public GameObject wav3Panel;

    public GameObject winPanel;

    bool w1C, w2C, w3C;


    private void Update()
    {
        
        if (!wav1Initiated)
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().NewWave();
            wav1Panel.SetActive(true);
            Destroy(wav1Panel, 3f);
            wav1.SetActive(true);
            wav1Initiated = true;
        }
        try
        {
            if (GameObject.FindGameObjectWithTag("Wav1").GetComponent<Wave1>().waveComplete && !w1C)
            {
                w1C = true;
                wav1.SetActive(false);
            }
        }
        catch
        {

        }

        if(w1C && !wav2Initiated)
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().NewWave();
            wav2Panel.SetActive(true);
            Destroy(wav2Panel, 3f);
            wav2.SetActive(true);
            wav2Initiated = true;
        }
        try
        {
            if (GameObject.FindGameObjectWithTag("Wav2").GetComponent<Wave2>().waveComplete && !w2C)
            {
                w2C = true;
                wav2.SetActive(false);
            }
        }
        catch
        {

        }
        

        if (w1C && w2C && !wav3Initiated)
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().NewWave();
            wav3Panel.SetActive(true);
            Destroy(wav3Panel, 3f);
            wav3.SetActive(true);
            wav3Initiated = true;
        }
        try
        {
            if (GameObject.FindGameObjectWithTag("Wav3").GetComponent<Wave3>().waveComplete && !w3C)
            {
                w3C = true;
                wav3.SetActive(false);
                winPanel.SetActive(true);
                GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().Won();
            }
        }
        catch
        {

        }
        
    }
}
