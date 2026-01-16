using UnityEngine;

public class CharacterPresenter : MonoBehaviour
{
    //component
    [SerializeField] private CharacterView _view;
    [SerializeField] private CharacterModel _model;

    //handler
    private CharacterDirectionHandler _directionHandler;
    private CharacterStepHandler _stepHandler;
    private CharacterResetHandler _resetHandler;

    void Awake()
    {
        //_model = new CharacterModel();
        GameService.Instance.Character = _model;
        _model.positions.Add(Vector2.zero);

        _directionHandler = new CharacterDirectionHandler(_model, _view);
        _stepHandler = new CharacterStepHandler(_model, _view);
        _resetHandler = new CharacterResetHandler(_model, _view);
    }

    void Start()
    {
        EventBus.Instance?.Subscribe<CharacterDirectionMessage>(_directionHandler.Execute);
        EventBus.Instance?.Subscribe<StageResetMessage>(_resetHandler.Execute);
    }

    void FixedUpdate()
    {
        _stepHandler.Execute();
    }
}
