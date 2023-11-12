using Npgsql;
using System.Data;

namespace communitradeRestServer.Models
{
    public class DBApplication
    {

        public Response GetAllItems(NpgsqlConnection con)
        {
            string Query = "select * from items";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();
            List<Item> items = new List<Item>();

            if (dt.Rows.Count > 0)
            {
                // if rows have values, need loop to add to student list
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Item item= new Item();
                    item.itemID = (int)dt.Rows[i]["itemid"]; // db column name
                    item.sellerID = (int)dt.Rows[i]["sellerid"]; // db column name
                    item.itemName = (string)dt.Rows[i]["itemname"];
                    item.description = (string)dt.Rows[i]["description"];

                    items.Add(item);
                }
            }
            if (items.Count > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Data retrieved successfully";
                response.items = items;
                response.item = null;
                response.user = null;
                response.users = null;
                response.message = null;
                response.messages = null;

            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Data failed to retrieve or maybe the table is empty";
                response.items = null;
                response.item = null;
                response.user = null;
                response.users = null;
                response.message = null;
                response.messages = null;
            }
            return response;
        }
        public Response AddUser(NpgsqlConnection con, User user)
        {
            con.Open();
            Response response = new Response();
            string Query = "INSERT INTO users VALUES (default, @username, @pass, @email)";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@pass", user.Password);
            cmd.Parameters.AddWithValue("@email", user.Email);

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Successfully inserted";
                response.items = null;
                response.item = null;
                response.user = user;
                response.users = null;
                response.message = null;
                response.messages = null;

            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Something went wrong";
                response.items = null;
                response.item = null;
                response.user = null;
                response.users = null;
                response.message = null;
                response.messages = null;
            }
            return response;
        }
    }
}
