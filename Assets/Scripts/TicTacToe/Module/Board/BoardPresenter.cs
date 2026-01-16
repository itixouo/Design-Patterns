using UnityEngine;

public class BoardPresenter : MonoBehaviour
{
    [SerializeField] private BoardView _view;
    private BoardModel _model;

    private BoardSetupHandler _setupHandler;
    private BoardMoveHandler _moveHandler;
    private BoardEvaluateHandler _evaluateHandler;
    void Awake()
    {
        _model = new BoardModel();
        _moveHandler = new BoardMoveHandler(_model, _view);
        _evaluateHandler = new BoardEvaluateHandler(_model, _view);
        _setupHandler = new BoardSetupHandler(_model, _view);

        EventBus.Instance.Subscribe<BoardEvaluateMessage>(_evaluateHandler.Execute);
    }

    void Start()
    {
        _evaluateHandler.Intialize();
        _moveHandler.Intialize();
    }


}
