using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : Singleton<SceneController>
{
    public string SceneTransitionName { get; private set; }

    public void SetTransitionName(string sceneTransitionName)
    {
        this.SceneTransitionName = sceneTransitionName;
    }

}


