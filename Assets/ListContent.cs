using UnityEngine;
using UnityEngine.UI;

public class ListContent : MonoBehaviour
{
    public GameObject textPrefab;

    void Start()
    {
        EventManager.StartListening("TODOS_FETCH", HandleTodosFetch);
        EventManager.StartListening("TODOS_CREATE", HandleTodosCreate);
        EventManager.StartListening("TODOS_UPDATE", HandleTodosUpdate);
        EventManager.StartListening("TODOS_DELETE", HandleTodosDelete);
    }

    void OnDestroy()
    {
        EventManager.StopListening("TODOS_FETCH", HandleTodosFetch);
        EventManager.StopListening("TODOS_CREATE", HandleTodosCreate);
        EventManager.StopListening("TODOS_UPDATE", HandleTodosUpdate);
        EventManager.StopListening("TODOS_DELETE", HandleTodosDelete);
    }

    public void HandleTodosFetch()
    {
        Global.Todos.ForEach(HandleForEachTodo);
    }

    public void HandleTodosCreate()
    {
        var textObj = Instantiate(textPrefab);
        var textComp = textObj.GetComponent<Text>();
        textComp.name = Global.TodoEvent.Id;
        textComp.text = Global.TodoEvent.Title;
        textObj.transform.SetParent(gameObject.transform);
    }

    public void HandleTodosUpdate()
    {
        var id = Global.TodoEvent.Id;
        var textObjTransform = gameObject.transform.Find(id);
        if (textObjTransform == null)
        {
            return;
        }
        var textComp = textObjTransform.gameObject.GetComponent<Text>();
        textComp.text = Global.TodoEvent.Title;
    }

    public void HandleTodosDelete()
    {
        var id = Global.TodoIdEvent;
        var textObjTransform = gameObject.transform.Find(id);
        if (textObjTransform == null)
        {
            return;
        }
        Destroy(textObjTransform.gameObject);

    }

    private void HandleForEachTodo(Todo todo)
    {
        var textObj = Instantiate(textPrefab);
        var textComp = textObj.GetComponent<Text>();
        textComp.name = todo.Id;
        textComp.text = todo.Title;
        textObj.transform.SetParent(gameObject.transform);
    }
}
