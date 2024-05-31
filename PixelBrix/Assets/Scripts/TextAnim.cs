using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TextAnim : MonoBehaviour
{
    public static TextAnim instance;
    private string fullText;
    private TMP_Text dialogue;
    public static Action OnAnimEnd;

    private void OnEnable()
    {
        dialogue = GetComponent<TMP_Text>();
        fullText = dialogue.text;
        dialogue.text = "";
        StartCoroutine(WriteOnByOne());
    }

    private IEnumerator WriteOnByOne()
    {
        foreach (char c in fullText)
        {
            dialogue.text += c;
            yield return new WaitForSeconds(0.15f);
        }
        OnAnimEnd?.Invoke();

    }
}
