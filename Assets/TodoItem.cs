using UnityEngine;

public class TodoItem : MonoBehaviour
{
    public void HandleClick()
    {
        Global.TodoIdEvent = name;
        EventManager.TriggerEvent("TODOS_DELETE");
    }
}
