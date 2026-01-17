using UnityEngine;

public class BoardEvaluateHandler
{
    private BoardModel _model;
    private BoardView _view;
    public BoardEvaluateHandler(BoardModel model, BoardView view)
    {
        _model = model;
        _view = view;
    }


    public void Intialize()
    {
        EventBus.Instance.Publish(new ReportTurnMessage() { turn = BoardService.Instance.Turn });
    }

    public void Execute(BoardEvaluateMessage message)
    {
        int winner = Evaluate();
        if (winner == 0)
        {
            if (IsAvaliable())
            {
                BoardService.Instance.FetchNextTurn();
                EventBus.Instance.Publish(new ReportTurnMessage() { turn = BoardService.Instance.Turn });
            }
            else
            {
                EventBus.Instance.Publish(new ReportResultMessage() { winner = 0 });
            }
        }
        else
        {
            EventBus.Instance.Publish(new ReportResultMessage() { winner = winner });
            DisbleAll();
        }
    }

    private void DisbleAll()
    {
        for (int i = 0; i < _view.InputButtons.Length; i++)
        {
            _view.InputButtons[i].interactable = false;
        }
    }

    private int Evaluate()
    {
        var slot = _model.slot;
        int width = slot.GetLength(0);

        for (int i = 0; i < width; i++)
        {
            if (slot[i, 0] != 0 && slot[i, 0] == slot[i, 1] && slot[i, 0] == slot[i, 2])
            {
                return slot[i, 0];
            }
                
            if (slot[0, i] != 0 && slot[0, i] == slot[1, i] && slot[0, i] == slot[2, i])
            {
                return slot[0, i];
            }
                
        }

        if (slot[1, 1] != 0 && slot[1, 1] == slot[0, 0] && slot[1, 1] == slot[2, 2])
            return slot[1, 1];

        if (slot[1, 1] != 0 && slot[1, 1] == slot[0, 2] && slot[1, 1] == slot[2, 0])
            return slot[1, 1];

        return 0;
    }

    private bool IsAvaliable()
    {
        var slot = _model.slot;
        int width = slot.GetLength(0);
        int height = slot.GetLength(1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (slot[x, y] == 0) return true;
            }
        }
        return false;
    }

}