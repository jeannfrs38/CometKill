using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene : MonoBehaviour
{
    public void SceneLoad(string scene)
    {
        UIManager.uiManagerInstance.SceneNext(scene);
    }
}
