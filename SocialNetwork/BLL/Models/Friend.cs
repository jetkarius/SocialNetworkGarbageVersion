using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public string Email { get; }
        public int Friend_id { get; }
        public string Name { get; internal set; }

        public Friend(int friend_id, string email)
        {
            Friend_id = friend_id;
            Email = email;
        }
    }
}