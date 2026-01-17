using UnityEngine;

public class BoardMoveHandler
{
    private BoardModel _model;
    private BoardView _view;
    public BoardMoveHandler(BoardModel model , BoardView view)
    {
        _model = model;
        _view = view;
    }

    public void Intialize()
    {
        for (int i = 0; i < _view.InputButtons.Length; i++)
        {
            int index = i;
            int x = i % 3;
            int y = i / 3;
            _view.InputButtons[index].onClick.AddListener(() => { OnSelectSlot(x, y, index); });
        }
    }

    public void OnSelectSlot(int x , int y , int index)
    {
        int turn = BoardService.Instance.Turn;
        _view.InputButtons[index].interactable = false;
        _view.SetColor(index, turn == 1 ? Color.red : Color.blue);
        _model.slot[x, y] = turn;

        EventBus.Instance.Publish<BoardEvaluateMessage>(default);
    }



}