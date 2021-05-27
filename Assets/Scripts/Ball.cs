using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    #region Variables

    [Header("Base Settings")]
    [SerializeField] private bool needToCentrate;
    [SerializeField] public Rigidbody2D rb;

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
    
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    private Transform padTransform;
    
    private bool isStarted;
    private Vector2 padOffset;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        padTransform = FindObjectOfType<Pad>().transform;

        if (needToCentrate)
        {
            CenterWithPad();
        }
        
        CalculatePadOffset();
    }

    private void Start()
    {
        if (NeedStartBall())
        {
            StartBall();
        }
    }

    private void Update()
    {
        if (!isStarted)
        {
            MoveWithPad();

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        audioSource.Play();
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

    public void Stick()
    {
        isStarted = false;
        rb.velocity = Vector2.zero;

        CalculatePadOffset();

        if (GameManager.Instance.IsAutoPlay)
        {
            Invoke(nameof(StartBall), 2f);
        }
    }

    #endregion


    #region Private methods

    private bool NeedStartBall()
    {
        return Input.GetMouseButtonDown(0) || GameManager.Instance.IsAutoPlay;
    }

    private void StartBall()
    {
        float x = Random.Range(randomMinX, randomMaxX);
        Vector2 direction = new Vector2(x, startDirectionY).normalized;
        Vector2 force = direction * speed;
        
        rb.velocity = force;
        isStarted = true;
    }

    private void MoveWithPad()
    {
        Vector2 padPosition = padTransform.position;
        padPosition -= padOffset;
        
        transform.position = padPosition;
    }

    private void CalculatePadOffset()
    {
        padOffset = padTransform.position - transform.position;
    }

    private void CenterWithPad()
    {
        var padPosition = padTransform.position;
        padPosition.y = transform.position.y;

        transform.position = padPosition;
    }

    #endregion
}
