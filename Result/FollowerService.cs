using Result.DTOs;

namespace Result
{
    public static class FollowerService
    {
        public static DTOs.Result StartFollowingAsync(int userId, int followedId)
        {
            if (userId == followedId)
            {
                return FollowerErrors.SameUser;
            }

            if (followedId > 10)
            {
                return FollowerErrors.NonePublicProfile;
            }

            if (IsAlreadyFollowingAsync(userId, followedId))
            {
                return FollowerErrors.AlreadyFollowing;
            }

            //var follower = Follower.Create(user.Id, followed.Id, utcNow);
            //Insert(follower);

            return Error.None;
        }

        private static bool IsAlreadyFollowingAsync(int id1, int id2)
        {
            return id1 < id2;
        }
    }
}