using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI crystalText;

    [Space(13)]
    
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button[] buyButton;
    [SerializeField] 
    private Button[] selectedButton;
    [SerializeField] 
    private Button[] selectButton;

    [Space(13)] 
    
    [SerializeField]
    private TextMeshProUGUI[] costText;
    [SerializeField] 
    private GameObject[] costGameObject;
    [SerializeField]
    private int[] cost = new int[] {0, 10, 15, 20, 15, 15};

    private void OnEnable()
    {
        SetCrystalText();
        SetCostText();
        SetKnightButtons();
        SetCostGameObject();
        
        StoreBuyButtonClickAction();
        StoreSelectButtonClickAction();
        StoreBackButtonClickAction();
    }

    private void OnDisable()
    {
        for (int i = 0; i < 3; i++)
        {
            if (StoreData.Instance.IsSelectedKnight(i))
            {
                PlayerPrefs.SetInt("SelectedKnight", i);
            }
            else
            {
                continue;
            }
        }

        if (StoreData.Instance.IsPurchasedShield())
        {
            PlayerPrefs.SetInt("PurchasedShield", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PurchasedShield", 0);
        }

        if (StoreData.Instance.IsPurchasedSphere())
        {
            PlayerPrefs.SetInt("PurchasedSphere", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PurchasedSphere", 0);
        }
    }

    private void StoreBackButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }
    }

    private void StoreBuyButtonClickAction()
    {
        if (buyButton[0] != null)
        {
            buyButton[0].onClick.AddListener(() =>
            {
                BuyKnight(0);
            });
        }

        if (buyButton[1] != null)
        {
            buyButton[1].onClick.AddListener(() =>
            {
                BuyKnight(1);
            });
        }

        if (buyButton[2] != null)
        {
            buyButton[2].onClick.AddListener(() =>
            {
                BuyKnight(2);
            });
        }

        if (buyButton[3] != null)
        {
            buyButton[3].onClick.AddListener(() =>
            {
                BuyKnight(3);
            });
        }

        if (buyButton[4] != null)
        {
            buyButton[4].onClick.AddListener(() =>
            {
                BuySphere();
            });
        }

        if (buyButton[5] != null)
        {
            buyButton[5].onClick.AddListener(() =>
            {
                BuyShield();
            });
        }
    }

    private void StoreSelectButtonClickAction()
    {
        if (selectButton[0] != null)
        {
            selectButton[0].onClick.AddListener(() =>
            {
                StoreData.Instance.SelectKnight(0);
                SetKnightButtons();
            });
        }

        if (selectButton[1] != null)
        {
            selectButton[1].onClick.AddListener(() =>
            {
                StoreData.Instance.SelectKnight(1);
                SetKnightButtons();
            });
        }

        if (selectButton[2] != null)
        {
            selectButton[2].onClick.AddListener(() =>
            {
                StoreData.Instance.SelectKnight(2);
                SetKnightButtons();
            });
        }

        if (selectButton[3] != null)
        {
            selectButton[3].onClick.AddListener(() =>
            {
                StoreData.Instance.SelectKnight(3);
                SetKnightButtons();
            });
        }
    }

    private void SetCrystalText()
    {
        crystalText.text = CrystalData.Instance.GetCrystalAmount().ToString();
    }

    private void BuySphere()
    {
        if (CrystalData.Instance.GetCrystalAmount() >= cost[4])
        {
            CrystalData.Instance.MinusCrystal(cost[4]);
            StoreData.Instance.BuySphere();
            SetKnightButtons();
            SetCrystalText();
            SetCostGameObject();
        }
    }

    private void BuyShield()
    {
        if (CrystalData.Instance.GetCrystalAmount() >= cost[5])
        {
            CrystalData.Instance.MinusCrystal(cost[5]);
            StoreData.Instance.BuyShield();
            SetKnightButtons();
            SetCrystalText();
            SetCostGameObject();
        }
    }

    private void BuyKnight(int index)
    {
        if (CrystalData.Instance.GetCrystalAmount() >= cost[index])
        {
            CrystalData.Instance.MinusCrystal(cost[index]);
            StoreData.Instance.BuyKnight(index);
            StoreData.Instance.SelectKnight(index);
            SetKnightButtons();
            SetCrystalText();
        }
    }

    private void SelectKnight(int index)
    {
        if (StoreData.Instance.IsPurchasedKnight(index))
        {
            StoreData.Instance.SelectKnight(index);
            SetKnightButtons();
        }
    }

    private void SetKnightButtons()
    {
        for (int i = 0; i < 4; i++)
        {
            if (StoreData.Instance.IsPurchasedKnight(i))
            {
                buyButton[i].gameObject.SetActive(false);

                if (StoreData.Instance.IsSelectedKnight(i))
                {
                    selectButton[i].gameObject.SetActive(false);
                    selectedButton[i].gameObject.SetActive(true);
                }
                else
                {
                    selectButton[i].gameObject.SetActive(true);
                    selectedButton[i].gameObject.SetActive(false);
                }
            }
            else
            {
                buyButton[i].gameObject.SetActive(true);
                selectButton[i].gameObject.SetActive(false);
                selectedButton[i].gameObject.SetActive(false);
            }
        }

        if (StoreData.Instance.IsPurchasedSphere())
        {
            buyButton[4].gameObject.SetActive(false);
            selectedButton[4].gameObject.SetActive(true);
        }
        
        else
        {
            buyButton[4].gameObject.SetActive(true);
            selectedButton[4].gameObject.SetActive(false);
        }

        if (StoreData.Instance.IsPurchasedShield())
        {
            buyButton[5].gameObject.SetActive(false);
            selectedButton[5].gameObject.SetActive(true);
        }

        else
        {
            buyButton[5].gameObject.SetActive(true);
            selectedButton[5].gameObject.SetActive(false);
        }
    }

    private void SetCostText()
    {
        for (int i = 0; i < costText.Length; i++)
        {
            costText[i].text = cost[i].ToString();
        }
    }

    private void SetCostGameObject()
    {
        for (int i = 0; i < 4; i++)
        {
            if (StoreData.Instance.IsPurchasedKnight(i))
            {
                costGameObject[i].SetActive(false);
            }
            else
            {
                costGameObject[i].SetActive(true);
            }
        }

        if (StoreData.Instance.IsPurchasedSphere())
        {
            costGameObject[4].SetActive(false);
        }
        else
        {
            costGameObject[4].SetActive(true);
        }

        if (StoreData.Instance.IsPurchasedShield())
        {
            costGameObject[5].SetActive(false);
        }
        else
        {
            costGameObject[5].SetActive(true);
        }
    }
}
