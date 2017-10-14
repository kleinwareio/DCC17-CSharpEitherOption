using System;
using LanguageExt;

namespace TimezoneNanoService
{
    public class OptionExample
    {
        public void CreationAndMap()
        {
            // I have no value
            Option<string> maybeString1 = Option<string>.None;
            // I do have a value
            Option<string> maybeString2 = Option<string>.Some("I have a value");

            // Still has no value, logic ignored
            Option<int> maybeLength1 = maybeString1.Select(str => str.Length);
            // Has value of 14
            Option<int> maybeLength2 = maybeString2.Select(str => str.Length);

            // has a value of 0
            int length1 = maybeLength1.IfNone(0);
            // has a value of 14
            int length2 = maybeLength2.IfNone(0);
        }

        public void chainingMapWhenReturningOption()
        {
            Option<int> intOption = Option<int>.Some(99);

            // `map` wraps an Option<Double> in another Option... very ugly =(
            Option<Option<double>> ugly = intOption.Map(value => squareRoot(value));

            // use `bind` to prevent the double-wrapping. Also known as `flatMap`.
            Option<double> maybeSquareRoot = intOption.Bind(value => squareRoot(value));

            // can chain bind and map together
            string result = intOption.Bind(value => squareRoot(value))
                                     .Map(sqrt => sqrt.ToString())
                                     .IfNone("Negative Value");
        }

        private Option<double> squareRoot(int value)
        {
            if (value < 0)
                return Option<double>.None;
            else
                return Option<double>.Some(Math.Sqrt(value));
        }
    }
}
