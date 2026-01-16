using UnityEngine;

public class CharacterStepHandler
{
    float timeCounter = 0;

    private CharacterModel _model;
    private CharacterView _view;
    public CharacterStepHandler(CharacterModel model, CharacterView view)
    {
        _model = model;
        _view = view;
    }

    public void Execute()
    {
        if (_model.death) return;

        timeCounter += Time.fixedDeltaTime;
        if (timeCounter > _model.speed)
        {
            timeCounter = 0;
            Move();
        }
    }

    public void Move()
    {
        _model.x += _model.direction.x;
        _model.y += _model.direction.y;

        var width = GameService.Instance.Stage.width;
        var height = GameService.Instance.Stage.height;

        if (_model.x > width)
            _model.x = -width;
        if (_model.x < -width)
            _model.x = width;
        if (_model.y > height)
            _model.y = -height;
        if (_model.y < -height)
            _model.y = height;

        Vector2 position = new Vector2(_model.x, _model.y);
        _model.positions.Insert(0, position);

        if (IsCollect())
        {
            _view.Add(position);

            GameService.Instance.Stage.score++;
            EventBus.Instance.Publish<StageSpawnMessage>(default);
            EventBus.Instance.Publish<ScoreUIMessage>(default);
        }
        else
        {
            _model.positions.RemoveAt(_model.positions.Count - 1);
            _view.Move(_model.positions);

            if (IsDeath())
            {
                _model.death = true;
                EventBus.Instance.Publish<DeathUIMessage>(default);
            }


        }
    }

    private bool IsCollect()
    {
        var item = GameService.Instance.Stage.itemPosition;
        if (_model.x == item.x && _model.y == item.y)
            return true;
        return false;
    }

    private bool IsDeath()
    {
        if (_model.positions.Count <= 1) return false; 
        for (int i = 1; i < _model.positions.Count; i++)
        {
            var position = _model.positions[i];
            if (position.x == _model.x && position.y == _model.y)
                return true;
        }
        return false;
    }
}