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

    private Ball ball;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
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

    #endregion
}
