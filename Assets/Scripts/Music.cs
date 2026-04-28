using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audi;
    public AudioClip[] myMusic = new AudioClip[3];
    // Use this for initialization
    void Awake()
    {
        audi = GetComponent<AudioSource>();
       // myMusic = Resources.LoadAll("Music", typeof(AudioClip)) as AudioClip[];
        audi.clip = myMusic[0] as AudioClip;
    }
    void Start()
    {

        audi.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audi.isPlaying)
            playRandomMusic();
    }
    void playRandomMusic()
    {
        audi.clip = myMusic[Random.Range(0, myMusic.Length)] as AudioClip;
        audi.Play();
    }
}
