using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class AddingToFriends
    {
        public AddingToFriends(FriendServices friendServices)
        {
            FriendServices = friendServices;
        }

        public FriendServices FriendServices { get; }

        public void Adding()
        {
            var friendData = new FriendData();

            Console.WriteLine("Введите email друга:");
            friendData.Email = Console.ReadLine();

            try
            {
                this.FriendServices.ValidData(friendData);
                SuccessMessage.Show("Успешно добавлен");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение.");
            }
        }
    }
}
