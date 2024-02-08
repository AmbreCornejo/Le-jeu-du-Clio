using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float InitialGameSpeed = 5f;
    public float GameSpeedIncrease = 0.1f;
    public float GameSpeed {get; private set;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        GameSpeed = InitialGameSpeed;
    }

    private void Update()
    {
        GameSpeed += GameSpeedIncrease * Time.deltaTime;
    }
}
