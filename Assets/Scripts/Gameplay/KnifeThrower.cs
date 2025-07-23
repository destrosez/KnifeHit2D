using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KnifeThrower : MonoBehaviour
{
    [SerializeField] private Text _countKnifeText;
    [SerializeField] private GameObject _knifePrefab;
    [SerializeField] private GameObject[] _logObjects;

    private float _throwForce = 15f;
    private float _moveSpeed = 0.1f;
    private float _refillDelayCounter;
    private float _logMoveDistance;
    private int _knifeCount = 8;
    private GameObject _currentKnife;
    private bool _shouldMove;
    private int _currentLogIndex;
    

    private void Start()
    {
        SpawnNewKnife();
        UpdateKnifeUI();
    }

    private void Update()
    {
        if (_shouldMove)
        {
            HandleLogMovement();
            return;
        }

        if (_knifeCount > 0)
        {
            HandleKnifeThrowInput();
        }

        if (AllApplesCollected() || _knifeCount == 0)
        {
            _shouldMove = true;
        }
    }


    private void HandleKnifeThrowInput()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ThrowKnife();
        }
    }

    private void ThrowKnife()
    {
        _knifeCount--;
        UpdateKnifeUI();

        _currentKnife.transform.parent = null;
        Rigidbody2D rb = _currentKnife.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * _throwForce, ForceMode2D.Impulse);

        SpawnNewKnife();
    }

    private void SpawnNewKnife()
    {
        _currentKnife = Instantiate(_knifePrefab, transform);
    }

    private void UpdateKnifeUI()
    {
        if (_countKnifeText != null)
        {
            _countKnifeText.text = _knifeCount.ToString();
        }
    }

    private void HandleLogMovement()
    {
        if (!Mathf.Approximately(_refillDelayCounter, 500))
        {
            _refillDelayCounter++;
        }
        else
        {
            _logMoveDistance += _moveSpeed;

            foreach (var log in _logObjects)
            {
                log.transform.position += Vector3.left * _moveSpeed;
            }

            if (_logMoveDistance >= 6f)
            {
                _knifeCount = 8;
                _logMoveDistance = 0;
                _refillDelayCounter = 0;
                _shouldMove = false;
                _currentLogIndex++;
                UpdateKnifeUI();
            }
        }
    }

    private bool AllApplesCollected()
    {
        if (_currentLogIndex >= _logObjects.Length) return false;

        GameObject currentLog = _logObjects[_currentLogIndex];
        foreach (Transform child in currentLog.transform)
        {
            if (child.CompareTag("Apple"))
                return false;
        }
        return true;
    }

}
