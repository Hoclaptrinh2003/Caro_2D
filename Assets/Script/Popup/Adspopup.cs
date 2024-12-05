using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;

public class Adspopup : MonoBehaviour,IPopup
{
    public float duration = 0.5f;
    [SerializeField] private int CoinRaward;
    [SerializeField] private TextMeshProUGUI CostText;

    private void OnEnable()
    {
        ShowPopup();
        CostText.text = CoinRaward.ToString();

    }


    public void Hide()
    {
        StartCoroutine(ClosePopup());
    }

    public void ShowPopup()
    {
        StartCoroutine(ScalePopup(Vector3.zero, Vector3.one));
    }

    public void HidePopup()
    {
        StartCoroutine(ScalePopup(Vector3.one, Vector3.zero));
    }


    private IEnumerator ScalePopup(Vector3 startScale, Vector3 endScale)
    {
        float timeElapsed = 0f;


        transform.localScale = startScale;


        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }


        transform.localScale = endScale;
    }

    public void WatchADS()
    {

        AudioManager.Instance.Win();

        ResourceManager.Instance.AddCoins(CoinRaward);
        StartCoroutine(ClosePopup());

    }

    private IEnumerator ClosePopup()
    {
        HidePopup();
        yield return new WaitForSeconds(duration);
        UImanager.Instance.Popup[3].SetActive(false);

    }
}
