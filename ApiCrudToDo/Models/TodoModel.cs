namespace ApiCrudToDo.Models
{
    public class TodoModel
    {
        
        public int id { get; set; }
        
        public string todo {  get; set; }
        public bool completed { get; set; }
        public int userId { get; set; }

        public override string ToString()
        {
            return $"ID: {id}\n Todo: {todo}\n Completed: {completed}\n UserId: {userId}\n ";
        }

    }
}
