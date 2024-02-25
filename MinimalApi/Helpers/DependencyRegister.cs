namespace MinimalApi_EfficientSendFile.Helpers
{
    public static class DependencyRegister
    {
        /// <summary>
        /// Initializes the ServiceCollection
        /// </summary>
        /// <returns>Returns the ServiceProvider as result of the ServiceCollection.Build</returns>
        public static IServiceProvider Register(this IServiceCollection sc)
        {
            return sc.BuildServiceProvider();
        }
    }
}
