using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float parallax;
    Material mat;
    Transform cam;
    Vector3 initialPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        cam = Camera.main.transform;
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.position.x, initialPos.y, initialPos.z);
        mat.mainTextureOffset = new Vector2(cam.position.x * parallax, 0);
    }
}
