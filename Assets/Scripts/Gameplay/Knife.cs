using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidBody;
    private bool _attachedToWood;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(nameof(Wood)))
        {
            _rigidBody.linearVelocity = Vector2.zero;
            transform.parent = collider.transform;
            _attachedToWood = true;
        }
        if (collider.CompareTag("Knife"))
        {
            Knife otherKnife = collider.GetComponent<Knife>();
            if (otherKnife != null && otherKnife._attachedToWood)
            {
                GameOverHandler.Instance.TriggerGameOver();
                Destroy(gameObject);
            }
        }

        if (collider.gameObject.CompareTag(nameof(Apple)))
        {
            Destroy(collider.gameObject);
        }
    }

    private void Update()
    {
        if (_attachedToWood && Mathf.Approximately(_rigidBody.gravityScale, 10))
        {
            Destroy(gameObject);
        }
    }
}
