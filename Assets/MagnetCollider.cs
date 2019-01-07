using UnityEngine;

public class MagnetCollider : MonoBehaviour {

    void Start()
    {
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sphereCollider.radius = PowerUpsDatabase.MagnetPowerUps[DataManager.LoadMagnetLevel()].Effect;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("magnet collider hit " + other.tag);
        switch (other.tag)
        {
            case "Coin":
                Coin coin = other.GetComponent<Coin>();
                coin.Follow(gameObject.transform.parent.gameObject);
                break;
        }
    }
}
