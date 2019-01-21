using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using UnityEngine.Events;

public class customButton : MonoBehaviour
{
    [SerializeField] bool isLink;
    [SerializeField] string url;


    [DllImport("__Internal")]
    private static extern void OpenWindow(string url);

    public void OnClick()
    {
        #if !UNITY_EDITOR
            if (isLink)
                OpenWindow(url);
        #endif
    }
}