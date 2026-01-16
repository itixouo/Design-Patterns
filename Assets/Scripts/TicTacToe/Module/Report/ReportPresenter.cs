using UnityEngine;

public class ReportPresenter : MonoBehaviour
{
    [SerializeField] private ReportView _view;
    private ReportTurnHandler _turnHandler;
    private ReportResultHandler _resultHandler;
    void Awake()
    {
        _turnHandler = new ReportTurnHandler( _view);
        _resultHandler = new ReportResultHandler(_view);

        EventBus.Instance.Subscribe<ReportTurnMessage>(_turnHandler.Execute);
        EventBus.Instance.Subscribe<ReportResultMessage>(_resultHandler.Execute);
    }

}
