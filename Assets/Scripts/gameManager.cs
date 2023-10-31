using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;

public class gameManager : MonoBehaviour
{

    // Start is called before the first frame update
    public Text timeTxt;
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;
    public static gameManager instance;
    public Animator animator;
    float time;

    //카드를 갖고오고 해당 카드를 똑같이 16번 찍으면 됨
    int[] rtans = new int[16];

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < rtans.Length; i++)
        {
            rtans[i] = (i / 2);
        }

        int[] randomRtansArray = rtans.OrderBy(rtan => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            float xpos = (i % 4) * 1.4f -2.1f;
            float ypos = (i / 4) * 1.4f -3.0f;

            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;
            newCard.transform.position = new Vector3 (xpos, ypos, 0);

            string rtanName = "rtan" + randomRtansArray[i].ToString();

            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }

    public void isMatched()
    {
        string firstCardName = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardName = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardName != secondCardName)
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }
        else
        {
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
