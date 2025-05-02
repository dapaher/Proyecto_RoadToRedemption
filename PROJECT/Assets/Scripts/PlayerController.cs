using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] Collider2D attackcol;
    [SerializeField] SpriteRenderer attackrender;
    [SerializeField] AudioClip sfxHit;
    Rigidbody2D rb;
    Collider2D col;
    Animator anim;
    float moveX;
    bool jump;
    bool attack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Run();
        Flip();
        Jump();
        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        if(!jump && Input.GetButtonDown("Jump")) jump = true;
        if(!attack && Input.GetKeyDown(KeyCode.Z)) attack = true;
    }

    void Run(){
        Vector2 vel = new Vector2(moveX * speed * Time.fixedDeltaTime, rb.linearVelocityY);
        rb.linearVelocity = vel;

        anim.SetBool("isRunning", Mathf.Abs(rb.linearVelocityX) > Mathf.Epsilon);
    }

    void Flip(){
        float vx = rb.linearVelocityX;
        if(Mathf.Abs(vx) > Mathf.Epsilon){
            transform.localScale = new Vector2(Mathf.Sign(vx), 1);
        }
    }

    void Jump(){
        if(!jump) return;
        jump = false;
        if(!col.IsTouchingLayers(LayerMask.GetMask("Terrain","Platforms"))) return;
        
        rb.linearVelocity += new Vector2(0, jumpSpeed);
        anim.SetTrigger("isJumping");
    }
    
    void Attack(){
        if(!attack) return;
        attack = false;
        anim.SetTrigger("isAttacking");
    }

    void EnableAttackRender(){ //Llamo a la funcion en la animacion
        attackrender.enabled = true;
    }
    void DisableAttackRender(){ //Llamo a la funcion en la animacion
        attackrender.enabled = false;
    }

    void EnableAttackCollider(){
        attackcol.enabled = true;
    }

    void DisableAttackCollider(){
        attackcol.enabled = false;
    }

    void PlaySfxHit(){
        AudioSource.PlayClipAtPoint(sfxHit, transform.position);
    }
}
