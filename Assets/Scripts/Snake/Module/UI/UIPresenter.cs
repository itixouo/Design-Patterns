using UnityEngine;

public class UIPresenter : MonoBehaviour
{
    [SerializeField] private ScoreUIView _scoreUIView;
    [SerializeField] private DeathUIView _deathUIView;
    private ScoreUIHandler _scoreUIHandler;
    private DeathUIHandler _deathUIHandler;

    void Awake()
    {
        _scoreUIHandler = new ScoreUIHandler(_scoreUIView);
        _deathUIHandler = new DeathUIHandler(_deathUIView);
    }
    void Start()
    {
        EventBus.Instance.Subscribe<ScoreUIMessage>(_scoreUIHandler.Execute);
        EventBus.Instance.Subscribe<DeathUIMessage>(_deathUIHandler.Execute);
    }


}
