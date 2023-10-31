using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openCard()
    {
        //�ش� ī���� active�� �ٲ��ָ��
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);

        
        if (gameManager.instance.firstCard == null)
        {
            gameManager.instance.firstCard = gameObject;
        }
        else
        {
            gameManager.instance.secondCard = gameObject;
            gameManager.instance.isMatched();
        }
    }

    public void destroyCard()
    {
        Invoke("invokeDestroyCard", 0.5f);
    }

    void invokeDestroyCard()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("invokeCloseCard", 0.5f);
    }

    void invokeCloseCard()
    {
        //ù��°, �ι�° ī�� ������
        gameObject.transform.Find("front").gameObject.SetActive(false);
        gameObject.transform.Find("back").gameObject.SetActive(true);
    }
}
