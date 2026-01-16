using UnityEngine;

public class StagePresenter : MonoBehaviour
{
    [SerializeField] private StageModel _model;
    [SerializeField] private StageView _view;

    private StageSpawnHandler _stageSpawnHandler;
    private StageResetHandler _stageResetHandler;
    private void Awake()
    {
        GameService.Instance.Stage = _model;
        _stageSpawnHandler = new StageSpawnHandler(_model ,_view);
        _stageResetHandler = new StageResetHandler(_model, _view);
    }

    private void Start()
    {
        EventBus.Instance.Subscribe<StageSpawnMessage>(_stageSpawnHandler.Execute);
        EventBus.Instance.Subscribe<StageResetMessage>(_stageResetHandler.Execute);
        _stageSpawnHandler.Execute(default);
    }
}
