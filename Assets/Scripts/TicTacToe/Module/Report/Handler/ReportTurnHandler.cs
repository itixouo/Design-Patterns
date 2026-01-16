public class ReportTurnHandler
{
    private ReportView _view;
    public ReportTurnHandler(ReportView view)
    {
        _view = view;
    }
    public void Execute(ReportTurnMessage message)
    {
        string value = $"Player {(message.turn == 1 ?"Red":"Blue")} turn";
        _view.SetText(value);
    }

}