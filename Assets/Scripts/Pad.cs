using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Unity lifecycle

    private void Update()
    {
       
       Vector3 positionInPixels = Input.mousePosition;
       Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(positionInPixels);

       Vector3 padPosition = positionInWorld;
       padPosition.y = transform.position.y;
       
       transform.position = padPosition;
    }

    #endregion
}
