using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAnim : MonoBehaviour
{
    public static TextAnim instance;
    private string fullText;
    private TMP_Text dialogue;

    private void Start()
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
    }
}