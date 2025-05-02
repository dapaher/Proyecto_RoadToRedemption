using UnityEngine;

public class ParallaxTitleScreen : MonoBehaviour
{

    [SerializeField] float parallax;
    Material mat;
    //Vector3 initialPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        //initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += new Vector2(parallax * Time.deltaTime, 0);
    }
}
