using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    //public static string namePlayer;

    [SerializeField]
    public static TMP_Text namePlayer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("NamePlayer");
        namePlayer = go.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
