using System;
using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    private Button buttonCmpt;

    void Awake()
    {
        buttonCmpt = GetComponent<Button>();
    }

    void Start()
    {
        EventManager.StartListening("TITLE_CHANGED", HandleTitleChanged);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("TITLE_CHANGED", HandleTitleChanged);
    }

    public void HandleClick()
    {
        Guid guid = Guid.NewGuid();
        string id = guid.ToString();
        Global.TodoEvent = new Todo()
        {
            Id = id,
            Title = Global.TitleEvent,
        };
        EventManager.TriggerEvent("TODOS_CREATE");
    }

    public void HandleTitleChanged()
    {
        var value = Global.TitleEvent;
        if (value != null && value.Trim() != "")
        {
            buttonCmpt.interactable = true;
            return;
        }
        buttonCmpt.interactable = false;
    }
}
