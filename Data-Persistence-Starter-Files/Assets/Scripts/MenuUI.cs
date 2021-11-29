using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuUI : MonoBehaviour
{
    public InputField inputName;
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveName()
    {
        MenuManager.Instance.PlayerName = inputName.text;
    }
}
