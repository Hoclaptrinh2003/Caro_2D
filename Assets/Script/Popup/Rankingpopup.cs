using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Rankingpopup : MonoBehaviour,IPopup
{
    public float duration = 0.5f;
    [SerializeField] private List<TextMeshProUGUI> playerNames;
    [SerializeField] private List<TextMeshProUGUI> playerWins;
    [SerializeField] private List<TextMeshProUGUI> playerLosses;



    private GameData gameData;
    private void OnEnable()
    {
        gameData = GameData.LoadData();

        UpdatePlayerRankings(gameData);

        ShowPopup();
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

    private IEnumerator ClosePopup()
    {
        HidePopup();
        yield return new WaitForSeconds(duration);
        UImanager.Instance.Popup[4].SetActive(false);

    }

    public void UpdatePlayerRankings(GameData gameData)
    {
        var sortedPlayers = gameData.players
            .Select(p => new
            {
                PlayerName = p.name,
                Wins = p.wins,
                Losses = p.losses,
                Points = p.wins - 0.5 * p.losses
            })
            .OrderByDescending(p => p.Points) 
            .ToList();

        for (int i = 0; i < sortedPlayers.Count; i++)
        {
            if (i < playerNames.Count && i < playerWins.Count && i < playerLosses.Count)
            {
                playerNames[i].text = sortedPlayers[i].PlayerName;
                playerWins[i].text = sortedPlayers[i].Wins.ToString();
                playerLosses[i].text = sortedPlayers[i].Losses.ToString();
            }
            else
            {
               
                break;
            }
        }
    }


}
