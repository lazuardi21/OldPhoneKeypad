
namespace OldPhonePadApp
{
  class Program
  {
    static void Main(string[] args)
    {
      while (true)
      {
        Console.Write("Enter input for OldPhonePad (or type 'exit' to quit): ");
        string input = Console.ReadLine();
        if (input.ToLower() == "exit")
        {
          break;
        }
        string result = IronSoftware.Challenge.OldPhoneKeypad.OldPhonePad(input);
        if (result != null)
        {
            Console.WriteLine(result);
        }
      }
    }
  }
}
