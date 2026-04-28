using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject center;
    public float speed = 10;
    public float radius = 2f;
    public float rspeed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = (transform.position - center.transform.position).normalized * radius + center.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAround();
    }

    void OrbitAround()
    {
        transform.RotateAround(center.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
