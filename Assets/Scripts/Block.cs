using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    [SerializeField] private int score;

    #endregion


    #region Events

    public static event Action OnCreated;
    public static event Action<int> OnDestroyed;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        OnCreated?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnDestroyed?.Invoke(score);

        Destroy(gameObject);
    }

    #endregion
}
