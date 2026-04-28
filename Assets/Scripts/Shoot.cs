using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate = 0.5f;
    float timer;
    public float force =100;
    AudioSource audi;
    public AudioClip laser;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") || Input.GetButton("Fire1"))
        {
            Fire();
        }
    }
    void Fire()
    {
        if(Time.time>fireRate + timer)
        {
            audi.PlayOneShot(laser);

            GameObject bullet = Objectpool.Instance.SpawnFromPool("Player Bullet", transform.position, Quaternion.identity);
            if (bullet == null)
                return;
            
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up*force);
            timer = Time.time;
        }
    }
}
