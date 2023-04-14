using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuScript : MonoBehaviour
{
    public GameObject NameInput;
    public void StartGame()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }

    private void SetPlayerName()
    {
        Debug.Log(NameInput.GetComponent<TMP_InputField>().text);
        PersistantDataManager.Instance.PlayerName = NameInput.GetComponent<TMP_InputField>().text;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
