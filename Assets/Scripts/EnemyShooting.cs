using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public int bulletAmount = 10;
    float startAngle = 90f, endAngle = 270f;
    Vector2 bulletMove;
    public float force = 100;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 3f);
    }

   
    void Fire()
    {
        
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletAmount+1; i++)
        {

            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVec = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 burDir = (bulMoveVec - transform.position).normalized;

            GameObject bullet = Objectpool.Instance.SpawnFromPool("Boss Splash", bulMoveVec, Quaternion.Euler(bulMoveVec));
            if (bullet == null)
                return;

            bullet.GetComponent<Rigidbody2D>().AddForce(burDir * force);

            angle += angleStep;
        }
        
    }
}
