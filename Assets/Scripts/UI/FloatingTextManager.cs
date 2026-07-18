using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager Instance;

    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowText(string text, Vector3 worldPosition)
    {
        GameObject obj = Instantiate(floatingTextPrefab, canvas.transform);

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        obj.GetComponent<RectTransform>().position = screenPosition;

        obj.GetComponent<FloatingText>().SetText(text);
    }

    
}