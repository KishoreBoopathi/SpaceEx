using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletTimer : BulletTimer
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Lifecounter>().hurt();

        }
        gameObject.SetActive(false);
    }
}
