using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    [SerializeField] private Text _appleCountFinal;
    [SerializeField] private Text _appleCountGame;
    private static int apples;

    private void Start()
    {
        if (apples > 0)
        {
            apples = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Knife"))
        {
            apples++;
            _appleCountFinal.text = apples + "/19";
            _appleCountGame.text = apples.ToString();
        }   
    }
}