using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MicController : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private PlayerController playerController;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    void Start()
    {
        actions.Add("Apri", Open);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += ReconSpech;
    }

    private void ReconSpech(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        actions[args.text].Invoke();
    }

    private void Open()
    {
     playerController = GetComponent<PlayerController>();
        playerController.OpenChest();
    }


}
