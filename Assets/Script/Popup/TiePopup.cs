using System.Collections;
using UnityEngine;

public class TiePopup : MonoBehaviour, IPopup
{
    public float animationDuration = 0.5f;
    private Vector3 targetScale = Vector3.one;
    private Vector3 initialScale = Vector3.zero;
    [SerializeField] private int indexSize;

    private void OnEnable()
    {
        indexSize = Board.Instance.BoardSize;
        transform.localScale = initialScale;
        ShowPopup();
    }

    public void ShowPopup()
    {
        StartCoroutine(ScalePopup(targetScale));
    }

    public void HidePopup()
    {
        gameObject.SetActive(false);
        CheckWin.Instance.isWin = false;
        Cell[] allCells = FindObjectsOfType<Cell>();
        foreach (Cell cell in allCells)
        {
            cell.isChange = false;
            cell.cellImage.sprite = cell.whiteCell_img;
        }
        Board.Instance.indexChange = 0;
        CheckWin.Instance.boardState = new string[indexSize, indexSize];
        CheckWin.Instance.winLength = indexSize < 5 ? 3 : 5;
    }

    private IEnumerator ScalePopup(Vector3 target)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            transform.localScale = Vector3.Lerp(startScale, target, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = target;
    }

    public void Home()
    {
        gameObject.SetActive(false);
        UImanager.Instance.Home();
    }
}
