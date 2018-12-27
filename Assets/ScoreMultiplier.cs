using UnityEngine;
using System.Collections;

public class ScoreMultiplier : MonoBehaviour
{
    public void Collect()
    {
        StartCoroutine(RemoveGameObject());
    }

    private IEnumerator RemoveGameObject()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(transform.parent.gameObject);
    }
}