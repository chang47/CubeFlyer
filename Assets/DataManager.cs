using UnityEngine;

public class DataManager 
{
    private static string _coinKey = "Coin";
    private static string _scoreKey = "Score";
    private static string _magnetLevelKey = "Magnet";
    private static string _multiplierLevelKey = "Multiplier";
    private static string _invincibleLevelKey = "Invincible";

    public static int LoadCoin()
    {
        return PlayerPrefs.GetInt(_coinKey, 0);
    }

    private static void SaveCoin(int coin)
    {
        PlayerPrefs.SetInt(_coinKey, coin);
    }

    public static int LoadScore()
    {
        return PlayerPrefs.GetInt(_scoreKey, 0);
    }

    private static void SaveScore(int score)
    {
        PlayerPrefs.SetInt(_scoreKey, score);
    }

    public static void AddCoin(int coin)
    {
        int totalCoin = LoadCoin() + coin;
        SaveCoin(totalCoin);
    }

    public static void BuyUpgrade(int coin)
    {
        int currentCoin = LoadCoin();
        if (currentCoin >= coin)
        {
            SaveCoin(currentCoin - coin);
        }
    }

    public static void AddNewScore(int score)
    {
        if (LoadScore() < score)
        {
            SaveScore(score);
        }
    }

    public static int LoadMagnetLevel()
    {
        return PlayerPrefs.GetInt(_magnetLevelKey, 0);
    }

    public static int LoadMultiplierLevel()
    {
        return PlayerPrefs.GetInt(_multiplierLevelKey, 0);
    }

    public static int LoadInvincibleLevel()
    {
        return PlayerPrefs.GetInt(_invincibleLevelKey, 0);
    }

    public static void IncreaseMagnetLevel()
    {
        IncreaseLevel(_magnetLevelKey, PowerUpsDatabase.MagnetPowerUps.Length - 1);
    }

    public static void IncreaseMultiplierLevel()
    {
        IncreaseLevel(_multiplierLevelKey, PowerUpsDatabase.MultiplierPowerUps.Length - 1);
    }

    public static void IncreaseInvincibleLevel()
    {
        IncreaseLevel(_invincibleLevelKey, PowerUpsDatabase.InvinciblePowerUps.Length - 1);
    }

    private static void IncreaseLevel(string upgradeKey, int upgradeMaxLevel)
    {
        int currentLevel = PlayerPrefs.GetInt(upgradeKey, 0);
        if (currentLevel < upgradeMaxLevel)
        {
            PlayerPrefs.SetInt(upgradeKey, currentLevel + 1);
        }
    }
}
