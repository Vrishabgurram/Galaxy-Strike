using UnityEngine;
using TMPro;

public class DialougeLines : MonoBehaviour
{
    [SerializeField] string[] voiceLines;
    [SerializeField] TMP_Text subtitleUI;

    int currentLine = 0;

    public void NextLine()
    {
        currentLine++;
        subtitleUI.text = voiceLines[currentLine];
    }
}
