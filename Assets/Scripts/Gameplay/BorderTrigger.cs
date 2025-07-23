using UnityEngine;

public class BorderTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Knife"))
        {
            Destroy(col.gameObject);
            GameOverHandler.Instance.TriggerGameOver();
        }
    }
}