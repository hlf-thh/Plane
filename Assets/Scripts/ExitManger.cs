using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManger : MonoBehaviour
{
    public void OnExitButtonClick()
    {
#if UNITY_EDITOR
        // 如果在编辑器中，停止播放模式
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // 如果在构建的应用程序中，退出应用程序
            Application.Quit();
#endif
    }
}

