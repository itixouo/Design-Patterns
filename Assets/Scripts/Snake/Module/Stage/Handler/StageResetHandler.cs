public class StageResetHandler
{
    private StageModel _model;
    private StageView _view;

    public StageResetHandler(StageModel model, StageView view)
    {
        _view = view;
        _model = model;
    }

    public void Execute(StageResetMessage message)
    {
        _model.score = 0;
        EventBus.Instance.Publish<ScoreUIMessage>(default);
        EventBus.Instance.Publish<StageSpawnMessage>(default);
    }
}