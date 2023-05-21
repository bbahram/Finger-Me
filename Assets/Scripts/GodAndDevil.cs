using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodAndDevil : MonoBehaviour
{
    [SerializeField] GameObject[] rocky;
    [SerializeField] GameObject star;
    [SerializeField] float offSet=0f;
    Vector2 rockPos;
    Vector2 starPos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        int random = Random.Range(0, 2);
        float[] randomPos = { Random.Range(-2, 2), Random.Range(10, 14) };
        if (collision.tag != "Star")
            if (random == 0)
            {
                rockPos = new Vector2(20, randomPos[0]);
                starPos = new Vector2(20.25f, randomPos[0]+ offSet);
                GameObject rockyTemp = Instantiate(rocky[random], rockPos, transform.rotation);
                GameObject starTemp= Instantiate(star, starPos, transform.rotation);
            }
            else
            {
                rockPos = new Vector2(20, randomPos[1]);
                starPos = new Vector2(20.25f, randomPos[1]-offSet);
                GameObject rockyTemp = Instantiate(rocky[random], rockPos, transform.rotation);
                GameObject starTemp = Instantiate(star, starPos, transform.rotation);
            }
    }
}
