using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public bool isSpinning;
    public float m_speedSpeed = 20;
    public AudioSource boomerang_sound;
    private void Awake()
    {
        isSpinning = false;
        TryGetComponent<AudioSource>(out boomerang_sound);
    }
    void FixedUpdate()
    {
        if(isSpinning){
            if(m_speedSpeed > 1)
            {
                transform.localRotation *= Quaternion.Euler(Vector3.down * m_speedSpeed);
            }
            else
            {
                ToggleSpinning(false);
            }
        }
    }

    public void ToggleSpinning(bool isSpinning)
    {
        this.isSpinning = isSpinning;
        if(isSpinning)
        {
            if(!boomerang_sound.isPlaying)
            {
                boomerang_sound.Play();
            }
        }
        else{
            boomerang_sound.Stop();
        }
    }
}
