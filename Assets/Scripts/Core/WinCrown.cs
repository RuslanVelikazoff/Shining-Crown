using UnityEngine;

public class WinCrown : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.WinGame();
        }
    }
}
