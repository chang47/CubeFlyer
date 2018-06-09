using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotater : MonoBehaviour {
	void Update () {
		transform.Rotate(Vector3.right * 3);
	}
}
