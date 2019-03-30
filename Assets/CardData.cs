using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int cardValue;
    [SerializeField] bool isAce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool getAce()
    {
        return isAce;
    }
    public int getValue()
    {
        return cardValue;
    }
}
