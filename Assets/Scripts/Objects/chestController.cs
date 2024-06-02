using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.Speech;

public class ChestController : MonoBehaviour
{
    public Sprite chestOpened;
    public Sprite chestClosed;
    private SpriteRenderer chestRenderer;
    private Renderer render;
    public GameObject Coin;
    private bool isThisChest;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    void Start()
    {
  
        chestRenderer = GetComponent<SpriteRenderer>();
        render = GetComponent<Renderer>();
        actions.Add("apri", Open);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += ReconSpech;

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        keywordRecognizer.Start();
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player" && chestRenderer.sprite == chestClosed && isThisChest == true)
        {
            chestRenderer.sprite = chestOpened;
            render.sortingOrder = 2;
            Instantiate(Coin, transform.position, Quaternion.identity);
            isThisChest = false;
            keywordRecognizer.Stop();
        }

    }

    private void ReconSpech(PhraseRecognizedEventArgs args)
    {
        string recognizedPhrase = args.text;
        Debug.Log("Recognized Phrase: " + recognizedPhrase);
        actions[args.text].Invoke();
    }


    private void Open()
    {
        isThisChest = true;
    }



    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}
