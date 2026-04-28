using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    [SerializeField] float padding = 1f;

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetUpMovementBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        //Input

        Movement();
    }

    void FixedUpdate()
    {
        //Movement
       
    }

    void LateUpdate()
    {
       
    }
    private void SetUpMovementBoundaries()
    {
        

        float widthRel = this.transform.localScale.y/ (Screen.width) / 2; 
        float heightRel = this.transform.localScale.x / (Screen.height) / 2; 

        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, widthRel, 1 - widthRel);
        viewPos.y = Mathf.Clamp(viewPos.y, heightRel, 1 - heightRel);
        this.transform.position = Camera.main.ViewportToWorldPoint(viewPos);

    }
    void Movement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        SetUpMovementBoundaries();
    }
}
