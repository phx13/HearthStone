using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMask : MonoBehaviour {
    public static BlackMask blackmask;
    void Awake()
    {
        blackmask = this;
        this.gameObject.SetActive(false);
    }
    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
