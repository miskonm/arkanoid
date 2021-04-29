using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    #endregion
}
