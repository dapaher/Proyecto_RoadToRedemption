using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    [SerializeField] AudioClip sxfCollectItem;
    Collider2D col;
    GameController gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider2D>();
        gameController = GameController.GetInstance();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){

            if(gameObject.tag == "Shell"){
                PlayItemSfx();
            }
            else if(gameObject.tag == "Life"){
                PlayItemSfx();
                gameController.AddLife();
            }
            
            Destroy(gameObject);
        }
    }

    void PlayItemSfx(){
        AudioSource.PlayClipAtPoint(sxfCollectItem, transform.position);
    }
}
