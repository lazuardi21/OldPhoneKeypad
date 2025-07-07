using System;
using Xunit;

namespace OldPhonePadApp.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        [InlineData("8 88777444666*6655 551#", "TURINKK&")]
        [InlineData("8 88777444666*6655 5511#", "TURINKK'")]
        [InlineData("8 88777444666*6655 55111#", "TURINKK(")]
        [InlineData("7777 999 666 0 66 3#", "SYO ND")]
        [InlineData("222 2 22#", "CAB")]
        [InlineData("2 2 2#", "AAA")]
        [InlineData("2*#", "")]
        [InlineData("0#", " ")]
        [InlineData("777 33 666 0 9 666 777#", "REO WOR")]
        [InlineData("33 888 555 2#", "EVLA")]
        [InlineData("5 5 5 5#", "JJJJ")]
        [InlineData("9999#", "Z")]
        [InlineData("9 999 9999#", "WYZ")]
        [InlineData("444*#", "")]
        [InlineData("444 666 3*3#", "IOD")]
        [InlineData("33 7777 666 0 999#", "ESO Y")]
        [InlineData("7 7 7 7#", "PPPP")]
        [InlineData("6 66 666#", "MNO")]
        [InlineData("1#", "&")]
        [InlineData("11#", "'")]
        [InlineData("111#", "(")]
        [InlineData("1111#", "&")]
        [InlineData("11 111 1#", "'(&")]
        [InlineData("227*11#", "B'")]
        [InlineData("4433555 5556661#", "HELLO&")]
        public void OldPhonePadTest(string input, string expectedOutput)
        {
            // Act
            string result = IronSoftware.Challenge.OldPhoneKeypad.OldPhonePad(input);

            // Assert
            Assert.Equal(expectedOutput, result);
        }
    }
}
