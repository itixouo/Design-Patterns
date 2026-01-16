using UnityEngine;

public class InputDirectionHandler
{
    private CharacterDirectionMessage _directionMessage = new CharacterDirectionMessage();
    public void Execute()
    {
        int horizontalInput = Mathf.RoundToInt( Input.GetAxis("Horizontal"));
        int verticalInput = Mathf.RoundToInt(Input.GetAxis("Vertical"));

        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (horizontalInput != 0)
                verticalInput = 0;

            _directionMessage.direction = new Vector2Int( horizontalInput, verticalInput);
            EventBus.Instance.Publish(_directionMessage);
        }

    }
}