using UnityEngine;
using Random = UnityEngine.Random;

public class SetPlayerName : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Username"))
        {
            string username = "User" + Random.Range(0, 999);
            
            PlayerPrefs.SetString("Username", username);
        }
    }
}
