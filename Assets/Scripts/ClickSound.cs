using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    private void Awake()
    {
        Button button = this.gameObject.GetComponent<Button>();
        
        if (button != null)
        {
            button.onClick.AddListener(()=> AudioManager.Instance.Play("Click"));
        }
    }
}
