using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;

    [Header("Life")]
    [SerializeField] private int maxLife = 3;

    [SerializeField] private LifeUI lifeUI;
    public int CurrentLife { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        CurrentLife = maxLife;
    }

    private void Start()
    {
        lifeUI.UpdateHearts();
       
    }

    public void AddLife(int amount = 1)
    {
        CurrentLife += amount;

        if (CurrentLife > maxLife)
            CurrentLife = maxLife;

        Debug.Log("Life : " + CurrentLife);

        lifeUI.UpdateHearts();
    }

    public void RemoveLife(int amount = 1)
    {
        CurrentLife -= amount;

        if (CurrentLife < 0)
            CurrentLife = 0;

        Debug.Log("Life : " + CurrentLife);

        if (CurrentLife == 0)
        {
            GameOver();
        }

        lifeUI.UpdateHearts();
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");
    }

    
}