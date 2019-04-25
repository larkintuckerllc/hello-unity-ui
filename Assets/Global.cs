using System.Collections.Generic;

public static class Global {
    static public string TitleEvent { get; set; }
    static public Todo TodoEvent { get; set; }
    static public string TodoIdEvent { get; set; }
    static public List<Todo> Todos { get; set; } = new List<Todo>();
}
