using UnityEngine;

public abstract class BasePickUp : MonoBehaviour
{
    #region Unity lifecycle

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tags.Pad))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }

    #endregion


    #region Private methods

    protected abstract void ApplyEffect();

    #endregion
}
