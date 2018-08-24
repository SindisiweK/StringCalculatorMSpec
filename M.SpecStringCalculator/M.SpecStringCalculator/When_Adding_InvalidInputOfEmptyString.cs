using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Machine.Specifications;
using Machine.Specifications.Model;

namespace M.SpecStringCalculator
{
    [Subject("Given invalid input")]
    public class When_Adding_InvalidInputOfEmptyString
    {
        private Establish context = () =>
        {
            Subject = new StringCalculator();
        };

        private Because of = () => Actual = Subject.Add("");

        private It Should_Return_Sum_Of_All_The_Input = () =>
        {
            Actual.Should().Be(0);
        };

        static StringCalculator Subject;
        static int Actual;
    }

    [Subject("Given_Numbers_Separated_By_Delimeters")]
    public class When_Adding_Numbers_Wth_Delimeters
    {
        private Establish context = () =>
        {
            Subject = new StringCalculator();
        };

        private Because of = () => Actual = Subject.Add("//;[*][%][?]\n1*2&3");

        private It Should_Return_Sum_Of_All_The_Input = () =>
        {
            Actual.Should().Be(6);
        };

        static StringCalculator Subject;
        static int Actual;
    }

    [Subject("Given Negative Values")]
    public class When_Input_Contains_Negative_Values
    {                                               
        private Establish context = () =>
        {
            Subject = new StringCalculator();
        };

        private Because of = () => _exception = Catch.Exception(() => Subject.Add("//;-1"));

        private It Should_Throw_An_Exception_With_Message = () => 
        {
            _exception.Message.Contains($"Negatives are not allowed{-1}");
        };

        static StringCalculator Subject;
        static Exception _exception;
    }
}
