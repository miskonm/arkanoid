using UnityEngine;

public class PickUpSpeed : BasePickUp
{
    #region Variables

    [SerializeField] private float speedFactor;

    #endregion


    #region Private methods

    protected override void ApplyEffect()
    {
        var ball = FindObjectOfType<Ball>();
        ball.ChangeSpeed(speedFactor);
    }

    #endregion
}
