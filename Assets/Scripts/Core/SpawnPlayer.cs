using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] player;
    [SerializeField] 
    private Animator[] playerAnimator;

    private GameObject currentGameObject;
    private Animator currentAnimator;

    private void Awake()
    {
        for (int i = 0; i < player.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("SelectedKnight"))
            {
                player[i].SetActive(true);
                currentGameObject = player[i];
                currentAnimator = playerAnimator[i];

                if (PlayerPrefs.GetInt("PurchasedShield") == 0)
                {
                    currentAnimator.SetBool("WithShield", false);
                }
                else
                {
                    currentAnimator.SetBool("WithShield", true);
                }
            }
        }
    }

    public Animator GetPlayerAnimator()
    {
        return currentAnimator;
    }

    public GameObject GetPlayerGameObject()
    {
        return currentGameObject;
    }
}
