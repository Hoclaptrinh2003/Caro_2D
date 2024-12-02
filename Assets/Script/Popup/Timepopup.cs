using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timepopup : MonoBehaviour,IPopup
{
    [SerializeField] private List<GameObject> time_Text;
    [SerializeField] private float speedShow_text;

    
    private void OnEnable()
    {
        ShowPopup(); 
    }
    public void ShowPopup()
    {
        StartCoroutine(ShowTextSequence());
    }

    public void HidePopup()
    {
        if (time_Text[time_Text.Count - 1].activeSelf == true)
        {
            StartCoroutine(hide());

        }
    }

    private void Update()
    {
        HidePopup();
    }
    private IEnumerator ShowTextSequence()
    {
        for (int i = 0; i < time_Text.Count; i++)
        {
            for (int j = 0; j < i; j++)
            {
                time_Text[j].SetActive(false);
            }

            time_Text[i].SetActive(true);

            yield return new WaitForSeconds(speedShow_text);
        }
    }

    private IEnumerator hide()
    {
     

        yield return new WaitForSeconds(speedShow_text);
        gameObject.SetActive(false);
        foreach (GameObject obj in time_Text)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

    }

}
