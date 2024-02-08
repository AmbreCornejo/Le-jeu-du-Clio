using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer Renderer;

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float speed = GameManager.Instance.GameSpeed / transform.localScale.x;

        Renderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
