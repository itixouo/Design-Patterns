using UnityEngine;

public class GameService
{
    public static GameService _instance;
    public static GameService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameService();
            }
            return _instance;
        }
    }

    public StageModel Stage { get => _stage; set => _stage = value; }

    private StageModel _stage;

    public CharacterModel Character { get => _character; set => _character = value; }

    private CharacterModel _character;
}
