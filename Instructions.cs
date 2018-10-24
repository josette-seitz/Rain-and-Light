using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour, IFadeText {
    public Text instrcText;
    public GameObject steam;

    private void Update()
    {
        if (Time.time > 43)
        {
            steam.transform.position += Vector3.up * (Time.deltaTime * 3f);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(FadeTextIn(3f, instrcText));
        steam.SetActive(true);
    }

    public IEnumerator FadeTextIn(float t, Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }
        if(text.color.a > 1.0f)
        {
            Invoke("DisableInstructions", 5f);
        }
    }

    private void DisableInstructions()
    {
        instrcText.gameObject.SetActive(false);
    }
}
