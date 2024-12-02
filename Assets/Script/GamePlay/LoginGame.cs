using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginGame : Singleton<LoginGame>   
{
    [SerializeField] private TMP_InputField Player_X_Name;
    [SerializeField] private TMP_InputField Player_O_Name;
    public TextMeshProUGUI UsernameText_X;
    public TextMeshProUGUI UsernameText_O;

    public void SetNamePlayer()
    {
        string usernameText_X = Player_X_Name.text.Trim();
        string usernameText_O = Player_O_Name.text.Trim();

        if (string.IsNullOrEmpty(usernameText_X))
        {
            usernameText_X = "Player_X"; 
        }

        if (string.IsNullOrEmpty(usernameText_O))
        {
            usernameText_O = "Player_O"; 
        }
        UsernameText_X.text = usernameText_X;
        UsernameText_O.text = usernameText_O;
        Board.Instance.ShowCell();
        foreach (GameObject obj in UImanager.Instance.GamePlay)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
        Board.Instance.isShowTextColer_X = false;    
        gameObject.SetActive(false);

    }
}
