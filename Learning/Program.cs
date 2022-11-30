using Learning.Model;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

List<TodoItem> InMemoryDB = new List<TodoItem>()
{
    new TodoItem("Clean Aquarium"),
    new TodoItem("Shop groceries"){Isdone=true},
    new TodoItem("Feed the snake"){Isdone=true},

};


app.MapGet("/todo", () =>
{
    return InMemoryDB;

});

app.MapPost("/todo", (TodoItem todoObj) =>
{   
    InMemoryDB.Add(todoObj);

});

app.MapPut("/todo/{identification}", (Guid identification) =>
{
    var ObjToEditIndex = InMemoryDB.FindIndex(td => td.Id == identification);
    if (InMemoryDB[ObjToEditIndex].Isdone == false)
    {
        InMemoryDB[ObjToEditIndex].Isdone = true;
    }
    else if (InMemoryDB[ObjToEditIndex].Isdone == true)
    {
        InMemoryDB[ObjToEditIndex].Isdone = false;
    }
});

app.MapDelete("/todo/{identification}", (Guid identification) =>
{
    var ObjToDeleteIndex = InMemoryDB.FindIndex(td => td.Id == identification);
    InMemoryDB.Remove(InMemoryDB[ObjToDeleteIndex]);

});



app.UseStaticFiles();
app.Run();

