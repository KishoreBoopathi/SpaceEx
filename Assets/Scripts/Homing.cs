using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    [SerializeField]
    private float speed = 15;

    [SerializeField]
    private float rotationSpeed = 1000;

    [SerializeField]
    private float focusDistance = 6;

    private Transform target;

    private bool isLookingAtObject = true;

    [SerializeField]
    private string targetTag;

    private string enterTagPls = "Please enter the tag of the object you'd like to target, in the field 'Target Tag' in the Inspector.";

    Rigidbody2D rb;
    private void Start()
    {
        if (targetTag == "")
        {
            Debug.LogError(enterTagPls);
            return;
        }

        target = GameObject.FindGameObjectWithTag(targetTag).transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (targetTag == "")
        {
            Debug.LogError(enterTagPls);
            return;
        }

        Vector2 targetDirection = target.position - transform.position;

        targetDirection.Normalize();

        float newDirection = Vector3.Cross(targetDirection, transform.up).z;

        rb.velocity = transform.up * speed;

        if (Vector2.Distance(transform.position, target.position) < focusDistance)
        {
            isLookingAtObject = false;
        }

        if (isLookingAtObject)
        {
            rb.angularVelocity = -newDirection * rotationSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Lifecounter>().hurt();

        }
        gameObject.SetActive(false);
    }
}
