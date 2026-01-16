public class DeathUIHandler
{
    private DeathUIView _view;

    public DeathUIHandler(DeathUIView view)
    {
        _view = view;
    }

    public void Execute(DeathUIMessage message)
    {
        if (GameService.Instance.Character.death)
        {
            _view.SetDeath("Death");
        }
        else
        {
            _view.SetDeath("");
        }
        
    }
}

