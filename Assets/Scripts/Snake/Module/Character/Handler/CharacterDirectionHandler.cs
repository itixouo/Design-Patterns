public class CharacterDirectionHandler
{
    private CharacterModel _model;
    private CharacterView _view;
    public CharacterDirectionHandler(CharacterModel model, CharacterView view)
    {
        _model = model;
        _view = view;
    }

    public void Execute(CharacterDirectionMessage message)
    {
        //prevent same axis direction change
        if (_model.direction.x != 0 && message.direction.y == 0)
            return;
        if (_model.direction.y != 0 && message.direction.x == 0)
            return;

        _model.direction = message.direction;
    }
}