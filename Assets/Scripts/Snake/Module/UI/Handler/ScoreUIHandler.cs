public class ScoreUIHandler
{
    private ScoreUIView _view;

    public ScoreUIHandler(ScoreUIView view)
    {
        _view = view;
    }

    public void Execute(ScoreUIMessage message)
    {
        int score = GameService.Instance.Stage.score;
        _view.SetScore(score);
    }
}