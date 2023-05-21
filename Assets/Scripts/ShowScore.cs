using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreSpcript scoreShow;
    // Start is called before the first frame update
    void Start()
    {
        scoreShow = FindObjectOfType<ScoreSpcript>();
        scoreText.text = scoreShow.ShowScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
