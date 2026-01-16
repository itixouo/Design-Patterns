using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private List<Transform> points = new List<Transform>();

    private void Start()
    {
        points.Add(point);
    }
    public void Add(Vector2 position)
    {
        var instance = Instantiate(point);
        points.Add(instance);
        instance.transform.position = position;
    }

    internal void Reset()
    {
        foreach (var p in points)
        {
            if (point != p)
            {
                Destroy(p.gameObject);
            }
        }
        points.Clear();
        points.Add(point);
        point.transform.position = Vector2.zero;
    }

    public void Move(Vector2 position)
    {
        point.transform.position = position;
    }

    public void Move(List<Vector2> positions)
    {
        for (int i = 0; i < positions.Count; i++)
        {
            points[i].transform.position = positions[i];
        }
    }
}
