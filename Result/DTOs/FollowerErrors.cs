using Result.DTOs;

public static class FollowerErrors
{
    public static readonly Error SameUser = new Error("Follower.SameUser", "Can't follow yourself");
    public static readonly Error NonePublicProfile = new Error("Follower.NonePublicProfile", "Can't follow non-public profiles");
    public static readonly Error AlreadyFollowing = new Error("Follower.AlreadyFollowing", "Already following");
}