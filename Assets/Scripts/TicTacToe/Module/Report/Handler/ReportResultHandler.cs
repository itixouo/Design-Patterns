public class ReportResultHandler
{
    private ReportView _view;
    public ReportResultHandler(ReportView view)
    {
        _view = view;
    }
    public void Execute(ReportResultMessage message)
    {
        string value;
        if (message.winner == 0)
        {
            value = $"Tie";
        }
        else
        {
            value = $"Winner {(message.winner == 1 ? "Red" : "Blue")}";
        }
        
        _view.SetText(value);
    }

}