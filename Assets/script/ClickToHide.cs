using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToHide : MonoBehaviour
{
    public int _TaskID = 0;
    public Text tasktEx;
    public void DoHide()
    {
        gameObject.SetActive(false);
        GameManager._Instance.CompleteTask(_TaskID);
    }
    public AudioClip onclick;
    private void OnDown()
    {
        DoHide();
        tasktEx.color = Color.green;
        AudioSource audiosource = GetComponentInParent<AudioSource>();
        audiosource.clip = onclick;
        audiosource.Play();
    }
    private bool mousein;
    private void OnMouseEnter()
    {
        mousein = true;
    }
    private void OnMouseExit()
    {
        mousein = false;
    }

    private void Update()
    {
        if(mousein)
        {
            if(Input .GetMouseButtonDown(1))
            {
                OnDown();
            }
        }
    }
}
