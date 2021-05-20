using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Variables

    [Header("Base Settings")]
    [SerializeField] private int score;
    [SerializeField] private GameObject destroyParticlePrefab;

    [Header("Pick Up")]
    [SerializeField] private GameObject pickUpPrefab;

    [Range(1, 100)]
    [SerializeField] private int pickUpCreationRate;

    [Header("Explosion")]
    [SerializeField] private bool isExplosive;
    [SerializeField] private float explosionRadius;
    [SerializeField] private GameObject explosionVfx;

    #endregion


    #region Events

    public static event Action OnCreated;
    public static event Action<int> OnDestroyed;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        OnCreated?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyBlock();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    #endregion


    #region Private methods

    public void DestroyBlock()
    {
        Destroy(gameObject);


        // Create pick up
        if (NeedCreatePickUp())
        {
            Instantiate(pickUpPrefab, transform.position, Quaternion.identity);
        }

        Explode();

        OnDestroyed?.Invoke(score);
    }

    private void Explode()
    {
        if (!isExplosive)
        {
            Instantiate(destroyParticlePrefab, transform.position, Quaternion.identity);
            
            return;
        }
        
        Instantiate(explosionVfx, transform.position, Quaternion.identity);
        
        LayerMask mask = LayerMask.GetMask(LayerNames.Block);
        var objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explosionRadius, mask);

        foreach (Collider2D objectInRadius in objectsInRadius)
        {
            Debug.Log($"Name: {objectInRadius.gameObject.name}");

            var block = objectInRadius.gameObject.GetComponent<Block>();

            if (block == null)
            {
                Destroy(objectInRadius.gameObject);
            }
            else
            {
                block.DestroyBlock();
            }
        }
    }

    private bool NeedCreatePickUp()
    {
        var randomNumber = Random.Range(1, 101);

        return pickUpCreationRate >= randomNumber;
    }

    #endregion
}
