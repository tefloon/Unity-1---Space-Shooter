using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Pocisk_dzwiek : MonoBehaviour
{
    [SerializeField] AudioClip dzwiekWybuchu;
    AudioSource odtwarzacz;


    // Start is called before the first frame update
    void Start()
    {
        odtwarzacz = GetComponent<AudioSource>();
        odtwarzacz.PlayOneShot(dzwiekWybuchu);
    }
}
