using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    #region Variables

    [Header("Score")]
    [SerializeField] private Text scoreLabel;

    [Header("Pause View")]
    [SerializeField] private PauseView pauseView;

    #endregion


    #region Unity lifecycle

    private void OnEnable()
    {
        PauseManager.OnPaused += PauseManager_OnPaused;
    }

    private void OnDisable()
    {
        PauseManager.OnPaused -= PauseManager_OnPaused;
    }

    #endregion


    #region Public methods

    public void SetScore(int score)
    {
        scoreLabel.text = score.ToString();
    }

    #endregion


    #region Private methods

    private void SetActivePauseView(bool isActive)
    {
        pauseView.gameObject.SetActive(isActive);
    }

    #endregion


    #region Event handlers

    private void PauseManager_OnPaused(bool isPaused)
    {
        SetActivePauseView(isPaused);
    }

    #endregion
}
