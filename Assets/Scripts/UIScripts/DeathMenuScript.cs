using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuScript : MonoBehaviour
{
    public string mainMenuScene;
    public GameObject deathPanel;
    public ScriptableObject resurrectPosition;

    // Start is called before the first frame update
    void Start()
    {
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMenu()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resurrect()
    {
        
    }

    public void QuitToMain()
    {
        //Descomentar quan tinguem el menú principal creat
        //SceneManager.LoadScene(mainMenuScene);
        //Time.timeScale = 1f;
    }
}
