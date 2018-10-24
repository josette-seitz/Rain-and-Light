using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour, IFadeText {
    public GameObject swirlIntro;
    public GameObject rain;
    public Text introText;
    private GameObject[] controllerScript;

    void Start () {
        StartCoroutine(FadeTextIn(6f, introText));
        controllerScript = GameObject.FindGameObjectsWithTag("GameController");
    }

    void Update()
    {
        if(Time.time > 17.75f)
        {
            swirlIntro.SetActive(false);
            foreach(GameObject cs in controllerScript)
            {
                cs.GetComponent<CreateParticles>().enabled = true;
            }
        }
        if(Time.time > 18f)
        {
            rain.SetActive(true);
        }
    }

    public IEnumerator FadeTextIn(float t, Text text)
    {
        yield return new WaitForSeconds(7f);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
