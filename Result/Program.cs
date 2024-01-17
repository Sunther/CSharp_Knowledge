using Result;

public class Program
{
    public static void Main()
    {
        int id1 = 0;
        int id2 = 1;
        var result = FollowerService.StartFollowingAsync(id1, id2);

        if (result.IsFailure)
        {
            //Log the result **result.Error.Description**
        }
    }
}
