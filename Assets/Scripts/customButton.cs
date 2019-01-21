using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class customButton : MonoBehaviour
{
    [SerializeField] bool isLink;
    [SerializeField] string url;
	[SerializeField] GameObject gameManager;

    public void OnClick()
    {
        if (isLink)
        {
			gameManager.GetComponent<link>().OpenLinkJSPlugin(url);
        }
    }
}
