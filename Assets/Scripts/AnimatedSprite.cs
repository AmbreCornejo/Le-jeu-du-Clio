using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] Sprites;

    public SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        frame++;
        if (frame >= Sprites.Length)
        {
            frame = 0;
        }

        if (frame >= 0 && frame < Sprites.Length)
        {
            spriteRenderer.sprite = Sprites[frame];
        }

        Invoke(nameof(Animate), 1f / GameManager.Instance.GameSpeed);
    }

}
