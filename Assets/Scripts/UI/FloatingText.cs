using UnityEngine;
using TMPro;
using System.Collections;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float lifeTime = 0.5f;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        float timer = 0;

        while (timer < lifeTime)
        {
            timer += Time.deltaTime;

            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            canvasGroup.alpha = 1 - (timer / lifeTime);

            yield return null;
        }

        Destroy(gameObject);
    }

    public void SetText(string value)
    {
        GetComponent<TextMeshProUGUI>().text = value;
    }
}