using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private float blinkSpeed = 0.5f;
    private Color colorA = Color.white;
    private Color colorB = new Color(169f / 255f, 24f / 255f, 24f / 255f);

    public Vector3 targetScale = new Vector3(1, 1, 1);
    public float scaleSpeed = 1f; 

    private void OnEnable()
    {
        StartCoroutine(BlinkText());
        StartCoroutine(ScaleObject()); 
    }

    void Start()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<TextMeshProUGUI>(); 
        }
    }

    private System.Collections.IEnumerator BlinkText()
    {
        while (true)
        {
            textComponent.color = colorA;
            yield return new WaitForSeconds(blinkSpeed);
            textComponent.color = colorB;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }

    private System.Collections.IEnumerator ScaleObject()
    {
        Vector3 initialScale = Vector3.zero; 
        float elapsedTime = 0f;

        while (elapsedTime < 1f) 
        {
            elapsedTime += Time.deltaTime * scaleSpeed; 
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime); 
            yield return null;
        }

        transform.localScale = targetScale; 
    }
}
