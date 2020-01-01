using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource aS = GetComponent<AudioSource>();
        aS.Play();
    }
}
