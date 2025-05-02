using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    GameController gameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = GameController.GetInstance();
    }

    void RestartGame(){
        gameController.RestartGame();
    }
    
    void ExitGame(){
        gameController.ExitGame();
    }
}
