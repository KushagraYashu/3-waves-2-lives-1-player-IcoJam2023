using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player;

    public static bool deadScreenBool;

    public GameObject deadScreen;

    public TextMeshProUGUI healthTxt;
    public TextMeshProUGUI livesText;
    


    // Start is called before the first frame update
    void Start()
    {
        deadScreenBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (deadScreenBool)
        {
            deadScreen.SetActive(true);
        }
        try
        {
            healthTxt.text = "" + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().curHealth;
            livesText.text = "" + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().livesLeft;
        }
        catch { }

    }

    public static void DeadScreenDisp()
    {
        deadScreenBool = true;
    }

}
