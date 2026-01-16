using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardView : MonoBehaviour
{
    public Button[] InputButtons => inputButtons;

    [SerializeField] private Button[] inputButtons;

    public void SetColor(int index , Color color)
    {
        inputButtons[index].targetGraphic.color = color;
    }

}
