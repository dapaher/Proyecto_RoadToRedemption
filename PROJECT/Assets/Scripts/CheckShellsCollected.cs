using UnityEngine;

public class CheckShellsCollected : MonoBehaviour
{
    GameController gameController;

    private void Start() {
        gameController = GameController.GetInstance();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            //Comprobar si tiene todas las conchas del nivel
            if(gameController.CheckShells() != 0) gameController.SendMessage("SendMsg","Te faltan conchas del camino por recoger\nVuelve cuando no te falte ninguna");
            else {
                gameController.SendMessage("SendMsg","¡Conseguiste todas las conchas de la zona! \nPuedes pasar la noche en mi albergue");
                gameController.NextLevel();
            }
        }
    }
}
