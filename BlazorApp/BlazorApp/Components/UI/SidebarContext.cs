// SidebarContext.cs — contexto partilhado via CascadingValue

namespace BlazorApp.Components.UI;

public class SidebarContext
{
    public required Func<bool> GetOpen { get; set; }
    public required Func<bool, Task> SetOpen { get; set; }
    public required Func<Task> ToggleSidebar { get; set; }

    public bool IsOpen => GetOpen();
    public string State => IsOpen ? "expanded" : "collapsed";
}
