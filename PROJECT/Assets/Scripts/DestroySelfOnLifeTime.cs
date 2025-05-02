using System.Collections;
using UnityEngine;

public class DestroySelfOnLifeTime : MonoBehaviour
{
    [SerializeField] float lifetime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("DestroySelf");
    }
    
    IEnumerator DestroySelf(){
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
