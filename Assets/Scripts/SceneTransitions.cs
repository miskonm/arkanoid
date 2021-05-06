using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransitions
{
    #region Variables

    private const string Tag = nameof(SceneTransitions);

    #endregion
    #region Public methods

    public static void GoToNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex < sceneCount)
        {
            SceneManager.LoadScene(nextSceneIndex);

            return;
        }
        
        Debug.LogError($"{Tag}, {nameof(GoToNextScene)}: There are no scene with index {nextSceneIndex}! " +
            $"Total scenes count {sceneCount}");
    }

    #endregion
}
