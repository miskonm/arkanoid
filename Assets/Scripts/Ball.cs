﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    #region Variables

    [Header("Base Settings")]
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform padTransform;

    [Header("Random Direction")]
    [SerializeField] private float speed;
    [SerializeField] private float startDirectionY;
    
    [Range(-5, 0)]
    [SerializeField] private float randomMinX;
    
    [Range(0, 5)]
    [SerializeField] private float randomMaxX;
    
    [Header("Speed")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;

    private bool isStarted;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        if (GameManager.Instance.IsAutoPlay)
        {
            StartBall();
        }
    }

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, rb.velocity);
    }

    #endregion


    #region Public methods

    public void ChangeSpeed(float speedFactor)
    {
        // rb.velocity = rb.velocity * speedFactor; same
        
        var newVelocityLength = Mathf.Clamp(rb.velocity.magnitude * speedFactor, minSpeed, maxSpeed);
        rb.velocity = rb.velocity.normalized * newVelocityLength;

        // rb.velocity *= speedFactor;
    }

    #endregion


    #region Private methods

    private void StartBall()
    {
        float x = Random.Range(randomMinX, randomMaxX);
        Vector2 direction = new Vector2(x, startDirectionY).normalized;
        Vector2 force = direction * speed;
        
        rb.velocity = force;
        isStarted = true;
    }

    #endregion
}
