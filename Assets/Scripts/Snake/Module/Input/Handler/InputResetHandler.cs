using UnityEngine;

public class InputResetHandler
{
    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EventBus.Instance.Publish<StageResetMessage>(default);
        }

    }
}