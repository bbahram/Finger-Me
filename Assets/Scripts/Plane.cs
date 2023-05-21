using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;
using System;
using UnityEditor;

public class Plane : MonoBehaviour
{
    [SerializeField] float xJump = 0.001f, yJump = 5f;
    [SerializeField] float minX = 0, maxX = 1;
    [SerializeField] float minY = 5, maxY = 1;
    [SerializeField] GameObject click;
    [SerializeField] float secs = 0f;
    [SerializeField] float screenUnitx = 18f;
    [SerializeField] float screenUnity = 12f;
    [SerializeField] float time = 0f;
    [SerializeField] TextMeshProUGUI forShowScore;
    Plane planePos;
    ScoreSpcript forScore;

    // Start is called before the first frame update
    void Start()
    {
        planePos = FindObjectOfType<Plane>();
        forScore = FindObjectOfType<ScoreSpcript>();
        Time.timeScale = 1f;
        if (Screen.width < Screen.height)
        {
            transform.position = new Vector2(8, 6);
        }
        else
            transform.position = new Vector2(3, 6);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenUnitx + " , " + Input.mousePosition.y / Screen.height * screenUnity);
        MoveNigga();
    }

    private void MoveNigga()
    {
        JumpOnFinger();
        Vector2 planeLimit = new Vector2(transform.position.x, transform.position.y);
        planeLimit.x = Mathf.Clamp(planePos.transform.position.x, minX, maxX);
        planeLimit.y = Mathf.Clamp(planePos.transform.position.y, minY, maxY);
        transform.position = planeLimit;
    }

    private IEnumerator TapTap()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x / Screen.width * screenUnitx, Input.mousePosition.y / Screen.height * screenUnity, -1);
        GameObject clickTemp = Instantiate(click, mousePos, transform.rotation);
        yield return new WaitForSeconds(secs);
        Destroy(clickTemp);
    }

    private void JumpOnFinger()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(xJump, yJump), ForceMode2D.Impulse);
            StartCoroutine(TapTap());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Star")
        {
            Destroy(collision.gameObject);
            forScore.CalScore();
            forShowScore.text = forScore.ShowScore().ToString();
            Time.timeScale+=time;
        }
        else
            FindObjectOfType<SessionController>().NextScene();
    }
}
