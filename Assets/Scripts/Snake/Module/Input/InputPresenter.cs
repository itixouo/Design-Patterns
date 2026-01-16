using UnityEngine;

public class InputPresenter : MonoBehaviour
{
    private InputDirectionHandler _directionHandler;
    private InputResetHandler _resetHandler;

    private void Awake()
    {
        _directionHandler = new InputDirectionHandler();
        _resetHandler = new InputResetHandler();
    }

    void Update()
    {
        _directionHandler.Execute();
        _resetHandler.Execute();
    }
}
