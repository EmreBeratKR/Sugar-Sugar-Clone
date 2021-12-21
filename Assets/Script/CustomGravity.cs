using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CustomGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private GravityController gravityController;
    const float gravityForce = -9.81f;


    private void Start()
    {
        gravityController = transform.parent.GetComponent<GravityController>();    
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.up * gravityForce * gravityController.gravityScale); 
    }
}
