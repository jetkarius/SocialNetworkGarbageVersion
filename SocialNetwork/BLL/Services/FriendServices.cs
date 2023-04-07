using SocialNetwork.BLL.Exceptions;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Models;
using System.Net.WebSockets;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    public class FriendServices 
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendServices()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public IEnumerable<Friend>GetFriendId(int friendId)
        {
            var friends = new List<Friend>();
            friendRepository.FindAllByUserId(friendId).ToList().ForEach(m =>
            {
                var userUserEntity = userRepository.FindById(m.user_id);
                var friendUserEntity = userRepository.FindById(m.friend_id);

                friends.Add(new Friend(m.friend_id,  friendUserEntity.email));
            });

            return friends;
        }

        public void ValidData(FriendData friendData)
        {
            

            if (!new EmailAddressAttribute().IsValid(friendData.Email))
                throw new ArgumentNullException();

            if (userRepository.FindByEmail(friendData.Email) == null)
                throw new ArgumentNullException();
        }
    }
}