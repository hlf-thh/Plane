using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManger : MonoBehaviour
{
    public void OnExitButtonClick()
    {
#if UNITY_EDITOR
        // ����ڱ༭���У�ֹͣ����ģʽ
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // ����ڹ�����Ӧ�ó����У��˳�Ӧ�ó���
            Application.Quit();
#endif
    }
}

