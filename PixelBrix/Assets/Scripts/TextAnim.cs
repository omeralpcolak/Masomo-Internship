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


    private void Awake()
    {
        instance = this;
    }

    public  void WriteOnebyOne(TMP_Text dialogue)
    {
        StartCoroutine(AnimRtn(dialogue));
    }

    private IEnumerator AnimRtn(TMP_Text dialogue)
    {
        fullText = dialogue.text;
        dialogue.text = "";

        foreach (char c in fullText)
        {
            dialogue.text += c;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
