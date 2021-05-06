using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    #region Variables

    [Header("Base Settings")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Random Direction")]
    [SerializeField] private float speed;
    [SerializeField] private float startDirectionY;

    [Range(-5, 0)]
    [SerializeField] private float randomMinX;

    [Range(0, 5)]
    [SerializeField] private float randomMaxX;

    private Transform padTransform;
    private bool isStarted;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        padTransform = FindObjectOfType<Pad>().transform;

        if (GameManager.Instance.IsAutoPlay)
        {
            StartBall();
        }
    }

    private void Update()
    {
        if (!isStarted)
        {
            Vector3 padPosition = padTransform.position;
            padPosition.y = transform.position.y;

            transform.position = padPosition;

            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, rb.velocity);
    }

    #endregion


    #region Private methods

    private void StartBall()
    {
        rb.velocity = GetRandomVelocity();
        isStarted = true;
    }

    private Vector2 GetRandomVelocity()
    {
        float x = Random.Range(randomMinX, randomMaxX);
        Vector2 direction = new Vector2(x, startDirectionY).normalized;
        Vector2 velocity = direction * speed;

        return velocity;
    }

    #endregion
}
