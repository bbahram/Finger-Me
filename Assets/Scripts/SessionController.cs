using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SessionController : MonoBehaviour
{
    ScoreSpcript des;
    // Start is called before the first frame update

    void Start()
    {
        des = FindObjectOfType<ScoreSpcript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadStartScene()
    {
        Destroy(des);
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    
}
