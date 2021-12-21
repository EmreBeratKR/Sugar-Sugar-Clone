using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravityScale;


    public void ReverseGravity()
    {
        gravityScale *= -1f;
    }
}
