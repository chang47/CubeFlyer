using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemStoreCanvasController : MonoBehaviour {
    public Text CoinText;
    public Button MagnetButton;
    public Button MultiplierButton;
    public Button InvincibleButton;

    private Text _magnetBuyText;
    private Text _multiplierBuyText;
    private Text _invincibleBuyText;

    void Start ()
    {
        DataManager.AddCoin(10000);
        _magnetBuyText = MagnetButton.GetComponentInChildren<Text>();
        _multiplierBuyText = MultiplierButton.GetComponentInChildren<Text>();
        _invincibleBuyText = InvincibleButton.GetComponentInChildren<Text>();
        UpdateUI();
    }

    private void UpdateUI()
    {
        CoinText.text = "Coin: " + DataManager.LoadCoin();
        UpdateUpgradeButton(DataManager.LoadMagnetLevel(), MagnetButton, _magnetBuyText, PowerUpsDatabase.MagnetPowerUps);
        UpdateUpgradeButton(DataManager.LoadMultiplierLevel(), MultiplierButton, _multiplierBuyText, PowerUpsDatabase.MultiplierPowerUps);
        UpdateUpgradeButton(DataManager.LoadInvincibleLevel(), InvincibleButton, _invincibleBuyText, PowerUpsDatabase.InvinciblePowerUps);
    }

    private void UpdateUpgradeButton(int upgradeLevel, Button button, Text text, PowerUpModel[] powerUpModels)
    {
        // if our upgrade level is at the max level already, we set the text to say it's maxed and disable the button
        if (upgradeLevel >= powerUpModels.Length - 1)
        {
            button.interactable = false;
            text.text = "Maxed";
            return;
        }

        // Show the cost as our purchase button, however if we can't afford it, disable the button
        int coin = DataManager.LoadCoin();
        int cost = powerUpModels[upgradeLevel].Cost;
        text.text = cost.ToString();
        if (coin < cost)
        {
            button.interactable = false;
        }
    }
	
	public void BuyMagnet()
    {
        print("buy magnet");
        int coin = DataManager.LoadCoin();
        int level = DataManager.LoadMagnetLevel();
        int cost = PowerUpsDatabase.MagnetPowerUps[level].Cost;

        if (coin >= cost)
        {
            DataManager.BuyUpgrade(cost);
            DataManager.IncreaseMagnetLevel();
            // When we make a purchase, we have to update our UI to reflect our new state
            UpdateUI();
        }
    }

    public void BuyMultiplier()
    {
        int coin = DataManager.LoadCoin();
        int level = DataManager.LoadMultiplierLevel();
        int cost = PowerUpsDatabase.MultiplierPowerUps[level].Cost;
        
        if (coin >= cost)
        {
            DataManager.BuyUpgrade(cost);
            DataManager.IncreaseMultiplierLevel();
            // When we make a purchase, we have to update our UI to reflect our new state
            UpdateUI();
        }
    }

    public void BuyInvincible()
    {
        int coin = DataManager.LoadCoin();
        int level = DataManager.LoadInvincibleLevel();
        int cost = PowerUpsDatabase.InvinciblePowerUps[level].Cost;

        if (coin >= cost)
        {
            DataManager.BuyUpgrade(cost);
            DataManager.IncreaseInvincibleLevel();
            // When we make a purchase, we have to update our UI to reflect our new state
            UpdateUI();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
