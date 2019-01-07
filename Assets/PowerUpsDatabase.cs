public class PowerUpModel
{
    public int Level;
    public float Effect;
    public int Cost;

    public PowerUpModel(int level, float effect, int cost)
    {
        this.Level = level;
        this.Effect = effect;
        this.Cost = cost;
    }
}

public static class PowerUpsDatabase {
    public static PowerUpModel[] MagnetPowerUps = {
        new PowerUpModel(0, 15, 50),
        new PowerUpModel(1, 20, 100),
        new PowerUpModel(2, 25, 200),
        new PowerUpModel(3, 30, 400),
        new PowerUpModel(4, 35, -1)
    };

    public static PowerUpModel[] MultiplierPowerUps =
    {
        new PowerUpModel(0, 2, 50),
        new PowerUpModel(1, 3, 100),
        new PowerUpModel(2, 4, 200),
        new PowerUpModel(3, 5, 400),
        new PowerUpModel(4, 6, -1)
    };

    public static PowerUpModel[] InvinciblePowerUps =
    {
        new PowerUpModel(0, 2, 50),
        new PowerUpModel(1, 2.25f, 100),
        new PowerUpModel(2, 2.5f, 200),
        new PowerUpModel(3, 2.75f, 400),
        new PowerUpModel(4, 3, -1)
    };
}
