using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Variables

    [Header("Movement Limit")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    private Transform ballTransform;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        ballTransform = FindObjectOfType<Ball>().transform;
    }

    private void Update()
    {
        Vector3 padPosition = Vector3.zero;

        if (GameManager.Instance.IsAutoPlay)
        {
            padPosition = ballTransform.position;
            padPosition.y = transform.position.y;
        }
        else
        {
            Vector3 positionInPixels = Input.mousePosition;
            Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(positionInPixels);

            padPosition = positionInWorld;
            padPosition.y = transform.position.y;
        }

        padPosition.x = Mathf.Clamp(padPosition.x, minX, maxX);
        transform.position = padPosition;
    }

    #endregion
}
