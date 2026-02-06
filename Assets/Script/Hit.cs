using UnityEngine;

public class Hit : MonoBehaviour
{
    #region OnCollision Function

    [SerializeField] private Material obstacleMaterial;
    [SerializeField] private Color matColor;

    [SerializeField] private float speed = 5f;

    // sphere color
    private MeshRenderer sphereRenderer;

    void Start()
    {
        // sphere renderer
        sphereRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //WASD
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");   

        Vector3 move = new Vector3(x, 0f, z);
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            MeshRenderer rend = collision.gameObject.GetComponent<MeshRenderer>();
            obstacleMaterial = rend.material;
            matColor = obstacleMaterial.color;

            // color swap
            Color sphereColor = sphereRenderer.material.color;

            sphereRenderer.material.color = matColor;
            obstacleMaterial.color = sphereColor;
        }
    }

    #endregion
}
