using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimer : MonoBehaviour
{
    public float countdown = 3f;
    public float damage = 100f;
    protected virtual void OnEnable()
    {
        Invoke("Destroy", countdown);
    }
   
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().ProcessHit(damage);
            
        }
        gameObject.SetActive(false);
    }

    protected virtual void Destroy()
    {
        gameObject.SetActive(false);
    }
    protected virtual void OnDisable()
    {
        CancelInvoke();
    }
}
