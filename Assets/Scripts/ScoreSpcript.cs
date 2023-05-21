using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpcript : MonoBehaviour
{
    [SerializeField] int point = 0;
    double currentPoint;
    // Start is called before the first frame update
    private void Awake()
    {
        int sceneCounter = FindObjectsOfType<ScoreSpcript>().Length;
        if (sceneCounter > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public double ShowScore()
    {
        return currentPoint;
    }
    public void CalScore()
    {
        currentPoint += point;
    }
}
