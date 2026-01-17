using UnityEngine;

public class BoardService
{
    public int Turn  => _turn; 

    private int _turn = 1;

    public int FetchNextTurn()
    {
        int turn = _turn;
        _turn = _turn * -1;
        return turn;
    }

    private static BoardService _instance;
    public static BoardService Instance
    {
        get
        {
            if (_instance == null)
                _instance = new BoardService();
            return _instance;
        }
    }
}
