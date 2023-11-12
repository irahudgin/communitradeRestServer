namespace communitradeRestServer.Models
{
    public class Response
    {
        public int statusCode { get; set; }

        public string messageCode { get; set; }

        public Item item { get; set; }
        public List<Item> items { get; set; }

        public Message message { get; set; }
        public List<Message> messages { get; set; }

        public User user { get; set; }
        public List<User> users { get; set; }   

    }
}
