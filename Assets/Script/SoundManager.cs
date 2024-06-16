using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource blip;
    public AudioSource fire;
    public AudioSource hit;
    public AudioSource hurt;
    public AudioSource dead;
    public AudioSource kill;
    public AudioSource newWave;
    public AudioSource lifeUsed;
    public AudioSource won;

    public void PlayBlip()
    {
        blip.Play();
    }

    public void NewWave()
    {
        newWave.Play();
    }

    public void PlayerDead()
    {
        dead.Play();
    }

    public void LifeUsed()
    {
        lifeUsed.Play();
    }

    public void Fire()
    {
        fire.Play();
    }

    public void Hit()
    {
        hit.Play();
    }

    public void Won()
    {
       won.Play();
    }

    public void Hurt()
    {
        hurt.Play();
    }

}
