using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    [Header("UI")]
    [SerializeField] private GameUi gameUi;

    [Header("Autoplay")]
    [SerializeField] private bool isAutoPlay;

    private int score;
    private bool isGamePaused;

    #endregion


    #region Properties

    public bool IsAutoPlay => isAutoPlay;

    #endregion


    #region Unity lifecycle

    private void OnEnable()
    {
        Block.OnDestroyed += Block_OnDestroyed;
    }

    private void OnDisable()
    {
        Block.OnDestroyed -= Block_OnDestroyed;
    }

    private void Start()
    {
        score = 0;
        UpdateScoreLabel();
    }

    #endregion


    #region Private methods

    private void AddScore(int score)
    {
        this.score += score;
        UpdateScoreLabel();
    }

    private void UpdateScoreLabel()
    {
        gameUi.SetScore(score);
    }

    #endregion


    #region Event handlers

    private void Block_OnDestroyed(int score)
    {
        AddScore(score);
    }

    #endregion
}
