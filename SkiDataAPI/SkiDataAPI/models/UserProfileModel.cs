namespace SkiDataAPI.models
{
    /// <summary>
    /// Model to hold user properties, registration model will hold a list of these
    /// to support multiple properties.
    /// </summary>
    public class UserProfileModel
    {
        public string Value;
        public string ProfilePropertyName;

        public UserProfileModel(string value, string profilePropertyName)
        {
            Value = value;
            ProfilePropertyName = profilePropertyName;
        }
    }
}
