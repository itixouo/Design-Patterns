using UnityEngine;

public class GameServiceTracker : MonoBehaviour
{
    [SerializeField] private CharacterModel character;
    [SerializeField] private StageModel stage;


    void Start()
    {
        character = GameService.Instance.Character;
        stage = GameService.Instance.Stage;

    }


}
