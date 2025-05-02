using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject enemyDeath;
    [SerializeField] float speed = 230f;
    [SerializeField] float patrolDistance = 1f;
    [SerializeField] bool moveRight;
    [SerializeField] AudioClip sfxEnemyDeath, sfxEnemyHit;
    float initialPos;
    float direction;
    float distanceTravelled;
    SpriteRenderer sprite;
    private int health = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        //Posición de inicio
        initialPos = transform.position.x;

        //Sentido del movimiento
        direction = moveRight ? 1 : -1;

    }

    // Update is called once per frame
    void Update()
    {
        float movement = speed * Time.deltaTime * direction;
        transform.Translate(new Vector2(movement, 0));

        distanceTravelled += Mathf.Abs(movement);

        if(distanceTravelled >= patrolDistance){
            direction *= -1;
            distanceTravelled = 0;
            sprite.flipX = !sprite.flipX;
        }

        if(health <= 0){
            AudioSource.PlayClipAtPoint(sfxEnemyDeath, transform.position);
            Instantiate(enemyDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Attack"){
            health -= 5;
            if(health <= 0) return;
            AudioSource.PlayClipAtPoint(sfxEnemyHit, transform.position);
            
        }
    }
}
