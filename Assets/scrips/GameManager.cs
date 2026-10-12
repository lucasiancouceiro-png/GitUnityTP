
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text itemsText;
    public GameObject victoryPanel;
    public int totalItems = 5;

    private int collectedItems = 0;
    private bool hasWon = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        collectedItems = 0;
        hasWon = false;

        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        UpdateUI();
    }

    public void CollectItem()
    {
        if (hasWon)
            return;

        collectedItems++;
        UpdateUI();

        if (collectedItems >= totalItems)
        {
            hasWon = true;

            if (victoryPanel != null)
                victoryPanel.SetActive(true);

            Debug.Log("¡Victoria!");
        }
    }

    void UpdateUI()
    {
        if (itemsText != null)
            itemsText.text = "Items: " + collectedItems + " / " + totalItems;
    }
}
