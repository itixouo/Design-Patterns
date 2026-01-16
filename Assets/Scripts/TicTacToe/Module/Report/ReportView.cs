using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReportView : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;
    public void SetText(string message)
    {
        resultText.text = message;
    }
}