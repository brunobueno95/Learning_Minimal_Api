using System.Globalization;

namespace Learning.Model
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Todo { get; set; }

        public bool Isdone { get; set; }

        public TodoItem(string todo) :this()
        {
            Todo = todo;
            

        }

        public TodoItem()
        {
            Isdone = false;
            Id = Guid.NewGuid();
        }
    }


}
