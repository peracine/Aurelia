using System;

namespace Core.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Registered { get; set; }
        public DateTime DueDate { get; set; }
        public bool Done { get; set; }
    }
}
