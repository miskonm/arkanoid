using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonMonoBehaviour<LevelManager>
{
    #region Variables

    private int blockCount;

    #endregion


    #region Unity lifecycle

    private void OnEnable()
    {
        Block.OnDestroyed += Block_OnDestroyed;
        Block.OnCreated += Block_OnCreated;
    }

    private void OnDisable()
    {
        Block.OnDestroyed -= Block_OnDestroyed;
        Block.OnCreated -= Block_OnCreated;
    }

    #endregion


    #region Private methods

    private void BlockCreated()
    {
        blockCount++;
    }

    private void BlockDestroyed()
    {
        blockCount--;

        if (blockCount <= 0)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        var sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.LoadNextScene();
    }

    #endregion


    #region Event handlers

    private void Block_OnDestroyed(int score)
    {
        BlockDestroyed();
    }

    private void Block_OnCreated()
    {
        BlockCreated();
    }

    #endregion
}
