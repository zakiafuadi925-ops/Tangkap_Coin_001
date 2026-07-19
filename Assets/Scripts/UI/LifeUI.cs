using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private Image[] hearts;

    private void Start()
    {
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        int currentLife = LifeManager.Instance.CurrentLife;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLife;
        }
    }
}