using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterModel 
{
    public int lenght;
    public float speed;
    public bool death;
    public Vector2Int direction;
    public int x;
    public int y;
    public List<Vector2> positions = new List<Vector2>();
}
