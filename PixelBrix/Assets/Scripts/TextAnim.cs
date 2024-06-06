using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TextAnim : MonoBehaviour
{
    private string fullText;
    private TMP_Text dialogue;
    public static Action<bool> OnDialogue;
    public float waitDuration;

    public void SetTheText()
    {
        dialogue = GetComponent<TMP_Text>();
        fullText = dialogue.text;
        dialogue.text = "";
        StartCoroutine(WriteOnByOne());
    }

    private IEnumerator WriteOnByOne()
    {
        OnDialogue?.Invoke(true);
        
        foreach (char c in fullText)
        {
            dialogue.text += c;
            yield return new WaitForSeconds(waitDuration);
        }

        OnDialogue?.Invoke(false);
    }
}
