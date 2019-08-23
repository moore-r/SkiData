using System.Collections.Generic;

namespace SkiDataAPI.models
{
    /// <summary>
    /// Model to hold data being sent to Skidata portal
    /// </summary>
    public class RegistrationRequestModel
    {
        public string Username;
        public string Password;
        public string RegistrationChannel;
        public List<UserProfileModel> UserProfileProperties;
    }
}
