using UnityEngine;

public class Coin : MonoBehaviour 
{
	public void Collect() {
		Destroy(gameObject);
	}
}
