using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> textLoad;
    [SerializeField] private Slider slider;
    [SerializeField] private int MaxValueSlider;

    void Start()
    {
        slider.maxValue = MaxValueSlider;
        StartCoroutine(ShowTextSequence());
    }
    void Update()
    {
        slider.value += Time.deltaTime;
        if (slider.value == slider.maxValue)
        {
            LoadNextScene();
        }
    }
    IEnumerator ShowTextSequence()
    {
        while (true)
        {

            foreach (var text in textLoad)
            {
                text.SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(0.1f);

            foreach (var text in textLoad)
            {
                text.SetActive(false);
            }

        }
    }

    void LoadNextScene()
    {

        SceneManager.LoadScene("MainGame");

    }

}
