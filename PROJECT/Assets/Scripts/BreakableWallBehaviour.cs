using UnityEngine;

public class BreakableWallBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] AudioClip sfxbreakwall;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Attack"){
            Instantiate(prefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(sfxbreakwall, transform.position);
            Destroy(gameObject);
        } 
    }
}
