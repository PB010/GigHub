﻿namespace GigHub.Core.Models
{
    public class Follow
    {
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followed { get; set; }
        public string FollowerId { get; set; }
        public string FollowedId { get; set; }
       
    }
}