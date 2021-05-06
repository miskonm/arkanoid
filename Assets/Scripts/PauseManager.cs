using System;
using UnityEngine;

public class PauseManager : SingletonMonoBehaviour<PauseManager>
{
    #region Variables

    private bool isPaused;

    #endregion


    #region Events

    public static event Action<bool> OnPaused;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    #endregion


    #region Public methods

    public void Toggle()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;

        OnPaused?.Invoke(isPaused);
    }

    #endregion
}
