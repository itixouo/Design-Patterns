using UnityEngine;
public class CharacterResetHandler
{
    private CharacterModel _model;
    private CharacterView _view;
    public CharacterResetHandler(CharacterModel model, CharacterView view)
    {
        _model = model;
        _view = view;
    }

    public void Execute(StageResetMessage message)
    {
        _view.Reset();
        _model.direction = Vector2Int.left;
        _model.positions.Clear();
        _model.x = 0;
        _model.y = 0;
        _model.death = false;
        _model.positions.Add(Vector2.zero);
        EventBus.Instance.Publish<DeathUIMessage>(default);
    }
}