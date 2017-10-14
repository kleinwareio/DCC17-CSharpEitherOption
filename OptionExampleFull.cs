using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;

namespace TimezoneNanoService
{
    class OptionExampleFull
    {
        IUserRepository userRepository;

        public interface IUserRepository
        {
            Option<User> getUser(int id);
        }

        public class User
        {
            public Preferences preferences;
        }

        public class Preferences
        {
            public Option<TimeZone> timeZone;
        }

        public Option<TimeZone> getTimezone(int userId)
        {
            return userRepository
                .getUser(userId)
                .Map(user => user.preferences)
                .Bind(preferences => preferences.timeZone);
        }
    }
}
