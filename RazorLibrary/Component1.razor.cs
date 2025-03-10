
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RazorLibrary;

[Route("/testRoute")]
public partial class Component1
{

    [Parameter]
    public int AnswerToEverything { get; set; } = 0;

    [CascadingParameter]
    public int AnswerToSomething { get; set; } = 0;

    [JSInvokable]
    public void JSInvokable()
    {

    }

    private int defaultAnswer = 42;
    public int DefaultAnswer = 42;

    public string GetString()
    {
        var number = 0;
        var test = number + 65;
        var str = $"Ich bin ein string in Component1. Answer to the universe: {AnswerToEverything}. Default {defaultAnswer + test + DefaultAnswer}";
        return str;
    }
}
