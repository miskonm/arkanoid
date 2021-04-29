using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private Transform padTransform;
    
    

    private bool isStarted;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (!isStarted)
        {
            // Move with pad
            Vector3 padPosition = padTransform.position;
            padPosition.y = transform.position.y;

            transform.position = padPosition;
            
            // If press left button
            //// Start ball
            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }
        
       
    }

    #endregion


    #region Private methods

    private void StartBall()
    {
        Vector2 force = direction * speed;
        rb.AddForce(force);
        isStarted = true;
    }

    #endregion
}
