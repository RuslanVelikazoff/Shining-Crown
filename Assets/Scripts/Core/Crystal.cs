using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.Play("Crystal");
            Destroy(this.gameObject);
            CrystalManager.Instance.AddCrystal();
        }
    }
}
