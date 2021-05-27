using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Variables

    [Header("Movement Limit")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    
    [Header("Vfx")]
    [SerializeField] private GameObject stickyVfxPrefab;
    
    private Ball ball;

    private bool isSticky;
    private GameObject stickyVfx;

    private float stickyTimer;
    
    #endregion


    #region Unity lifecycle

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        
        
    }

    private void Update()
    {
        TickStickyTimer();
        
        if (GameManager.Instance.IsAutoPlay)
        {
            Vector3 padPosition = ball.transform.position;
            padPosition.y = transform.position.y;
            padPosition.x = Mathf.Clamp(padPosition.x, minX, maxX);
            transform.position = padPosition;
        }
        else
        {
            Vector3 positionInPixels = Input.mousePosition;
            Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(positionInPixels);

            Vector3 padPosition = positionInWorld;
            padPosition.y = transform.position.y;

            padPosition.x = Mathf.Clamp(padPosition.x, minX, maxX);

            transform.position = padPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isSticky && other.gameObject.CompareTag(Tags.Ball))
        {
            var ball = other.gameObject.GetComponent<Ball>();
            ball.Stick();
        }
    }

    #endregion


    public void MakeSticky(float duration)
    {
        isSticky = true;

        if (stickyVfx == null)
        {
            stickyVfx = Instantiate(stickyVfxPrefab, transform);
        }

        stickyTimer = duration;
        // Invoke(nameof(StopSticky), duration);
    }

    private void StopSticky()
    {
        Debug.Log($"StopSticky");
        
        isSticky = false;

        if (stickyVfx != null)
        {
            Destroy(stickyVfx);
            stickyVfx = null;
        }
    }

    private void TickStickyTimer()
    {
        if (!isSticky)
        {
            return;
        }
        
        if (stickyTimer > 0)
        {
            stickyTimer -= Time.deltaTime;
        }
        else
        {
            StopSticky();
        }
    }
}
