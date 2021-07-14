using System;

namespace todo_cli.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Done { get; set; }

        public static void CopyProp(Todo dest, Todo src)
        {
            dest.Title = src.Title;
            dest.Detail = src.Detail;
            dest.CreateTime = src.CreateTime;
            dest.EndTime = src.EndTime;
            dest.Done = src.Done;
        }

        public string DoneIcon() =>
            Done ? "✅" : "❌";

        public DateTime TimeDisplayResponseDone() =>
            Done ? EndTime : CreateTime;
    }
}
