using System;
using System.IO;
using System.Text;
using BankingAppTask;
using Moq;
using NUnit.Framework;

namespace BankingAppTests
{

    /// <summary>
    /// Testing strategy came from https://www.youtube.com/watch?v=_9O_ufnM3BU
    /// I used a console app in hopes to make my life easier for the testing side
    /// as I was struggling to picture the test cases. I was not expecting the difficulty
    /// that came with it.
    /// </summary>
    public class ConsoleTests
    {
        StringBuilder _output;
        Mock<TextReader> _input;

        [SetUp]
        public void Setup()
        {
            _output = new StringBuilder();
            var outputWriter = new StringWriter(_output);
            _input = new Mock<TextReader>();
            Console.SetOut(outputWriter);
            Console.SetIn(_input.Object);
        }

        [Test]
        public void MainMenu_Login()
        {
            UserResponses("1", "111111", "1111");
            var prompt = " Main Menu ";
            var consoleOutput = RunAppAndProduceOutput();

            Assert.AreEqual(prompt, consoleOutput[0]);
        }

        private string[] RunAppAndProduceOutput()
        {
            AppStart.Main(default);
            return _output.ToString().Split();
        }

        private MockSequence UserResponses(params string[] userResponses)
        {
            var sequence = new MockSequence();
            foreach (var response in userResponses)
                _input.InSequence(sequence).Setup(x => x.ReadLine()).Returns(response);
            return sequence;
        }

    }
}
