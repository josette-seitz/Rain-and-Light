using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IFadeText {

    IEnumerator FadeTextIn(float t, Text text);
}
