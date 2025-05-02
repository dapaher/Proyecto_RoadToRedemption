using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] AudioClip sfxPlayerDie;
    [SerializeField] CinemachineCamera followCamera;
    Vector3 initialPos;
    Rigidbody2D rb;
    Collider2D col;
    GameController gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = GameController.GetInstance();
        initialPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Traps" || collision.gameObject.tag == "Slug" ||collision.gameObject.tag == "Trasno"){
            StartCoroutine("DieAndReset");
        }
    }

    IEnumerator DieAndReset(){
        //Reproducir sonido de muerte
        AudioSource.PlayClipAtPoint(sfxPlayerDie, transform.position);

        //Llamamos al método LoseLife() del GameController
        gameController.LoseLife();

        //Desactivamos cámara
        followCamera.enabled = false;

        rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        col.enabled = false;

        //Si al jugador no le quedan vidas llamo al método GameOver del GameController y salgo de este método luego
        if(gameController.GetLives() == 0){
            gameController.GameOver();
            yield return null;
        }

        yield return new WaitForSeconds(3.5f);

        //Eliminar la velocidad del jugador
        rb.linearVelocity = Vector2.zero;
        transform.position = initialPos;
        col.enabled = true;
        followCamera.enabled = true;
    }
}
