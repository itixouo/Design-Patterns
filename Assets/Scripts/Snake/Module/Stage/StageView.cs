using UnityEngine;

public class StageView : MonoBehaviour
{
    [SerializeField] private Transform item;

    public void SetItemPosition(Vector2 position)
    {
        item.position = position;
    }
}