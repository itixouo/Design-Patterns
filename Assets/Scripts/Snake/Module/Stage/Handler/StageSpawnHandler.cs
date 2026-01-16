using UnityEngine;

public class StageSpawnHandler
{
    private StageModel _model;
    private StageView _view;

    public StageSpawnHandler(StageModel model, StageView view)
    {
        _view = view;
        _model = model;
    }

    public void Execute(StageSpawnMessage message)
    {
        int x, y;
        do
        {
             x = Random.Range(-_model.width, _model.width);
             y = Random.Range(-_model.height, _model.height);
        } while (!IsAvailable(x,y));

        _model.itemPosition = new Vector2Int(x,y);
        _view.SetItemPosition(new Vector2Int(x, y));
    }

    private bool IsAvailable(float x , float y)
    {
        foreach (var position in GameService.Instance.Character.positions)
        {
            if (position.x == x && position.y == y)
                return false;
        }
        return true;
    }
}