using System.Collections;
using TMPro;
using UnityEngine;

public class TextLerp : MonoBehaviour
{
    [SerializeField] float duration = 2;
    TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine("Loop");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Loop(){
        while(true){
            yield return StartCoroutine(AlphaLerp(0f, 1f));
            yield return StartCoroutine(AlphaLerp(1f, 0f));
        }
    }

    IEnumerator AlphaLerp(float startAlpha, float endAlpha){
        float time = 0;
        Color startColor = text.color;
        startColor.a = startAlpha;
        Color endColor = text.color;
        endColor.a = endAlpha;

        while(time < duration){
            time += Time.deltaTime;
            text.color = Color.Lerp(startColor, endColor, time/duration);
            yield return null;
        }

        text.color = endColor;
    }
}
