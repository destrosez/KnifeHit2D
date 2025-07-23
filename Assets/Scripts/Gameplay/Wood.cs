using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour
{
    [SerializeField] private Text _scoreLoseText;
    
    private float _rotationSpeed = 4f;
    private static int _knifeHitCount;

    private void Start()
    {
        _knifeHitCount = 0;
    }

    private void FixedUpdate()
    {
        RotateLog();

        if (_knifeHitCount == 40)
        {
            GameOverHandler.Instance.TriggerGameOver();
        }
    }

    private void RotateLog()
    {
        transform.Rotate(0, 0, _rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Knife"))
        {
            _knifeHitCount++;
        }
    }
}