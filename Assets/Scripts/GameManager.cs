using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    [Header("UI")]
    [SerializeField] private Text scoreLabel;
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private GameObject pauseViewPrefab;

    [Header("Autoplay")]
    [SerializeField] private bool isAutoPlay;

    private int score;
    private bool isGamePaused;
    private GameObject pauseView;

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
        // pauseViewGameObject.SetActive(false);

        score = 0;
        UpdateScoreLabel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    #endregion


    #region Public methods

    public void AddScore(int score)
    {
        this.score += score;
        UpdateScoreLabel();
    }

    #endregion


    #region Private methods

    

    private void UpdateScoreLabel()
    {
        scoreLabel.text = score.ToString();
    }

    private void TogglePause()
    {
        isGamePaused = !isGamePaused;

        Time.timeScale = isGamePaused ? 0f : 1f;

        // if (isGamePaused)
        // {
        //     Time.timeScale = 0f;
        // }
        // else
        // {
        //     Time.timeScale = 1f;
        // }

        // pauseViewGameObject.SetActive(isGamePaused);

        if (isGamePaused)
        {
            pauseView = Instantiate(pauseViewPrefab, canvasTransform);
        }
        else
        {
            Destroy(pauseView);
        }
    }

    #endregion


    #region Event handlers

    private void Block_OnDestroyed(int score)
    {
        AddScore(score);
    }

    #endregion
}
