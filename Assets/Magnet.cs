﻿using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour
{
    public void Collect()
    {
        StartCoroutine(RemoveGameObject());
    }

    private IEnumerator RemoveGameObject()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}