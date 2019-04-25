using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    InputField inputFieldCmpt;

    private void Awake()
    {
        inputFieldCmpt = GetComponent<InputField>();
    }

    void Start()
    {
        EventManager.StartListening("TODOS_CREATE", HandleTodosCreate);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("TODOS_CREATE", HandleTodosCreate);
    }

    public void HandleValueChanged(string value)
    {
        Global.TitleEvent = value;
        EventManager.TriggerEvent("TITLE_CHANGED");
    }

    public void HandleTodosCreate()
    {
        inputFieldCmpt.text = null;
    }
}
