using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;

namespace TimezoneNanoService
{
    class EitherExample
    {
        public void Example()
        {

            // an Either in the "right" state with a value of "Success!"
            Either<Exception, string> result1 = "Success!";
            // an Either in the "left" state that is holding an exception object
            Either<Exception, string> result2 = new Exception("poof");

            // this Either is in the Right state with a value of 8
            Either<Exception, int> resultLength1 = result1.Map(str => str.Length);
            // this Either is in the Left state with the same exception object as above
            Either<Exception, int> resultLength2 = result1.Map(str => str.Length);

            // this Either is in the "right" state, so the length as a string is returned
            string finalValue1 = resultLength1.Match(len =>len.ToString(), ex => ex.Message);
            // this Either is in the "left" state, so the exception message is returned
            string finalValue2 = resultLength2.Match(len =>len.ToString(), ex => ex.Message);
        }

        private enum Error
        {
            UserNotFound,
            AgeNotSet
        }

        private class User
        {
            public Option<int> getAge()
            {
                return Option<int>.Some(42);
            }
        }

        public string getAge(int userId)
        {
            return getUser(userId)
                .Bind(user => getAge(user))
                .Map(age => age.ToString())
                .Match(age => age, error => error.ToString());
        }

        private Either<Error, User> getUser(int userId)
        {
            if (userId < 100)
                return Error.UserNotFound;
            else
                return new User();
        }

        private Either<Error, int> getAge(User user)
        {
            return user.getAge()
                       .Map(age=> (Either<Error,int>) age)
                       .IfNone(Error.AgeNotSet);
        }
    }
}
