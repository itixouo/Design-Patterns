using TMPro;
using UnityEngine;

public class DeathUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text deathText;

    public void SetDeath(string message)
    {
        deathText.text = $"{message}";
    }
}
