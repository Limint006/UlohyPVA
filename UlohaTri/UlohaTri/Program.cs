ulong result;

Console.WriteLine("Enter number to calculate from: ");
if (!ulong.TryParse(Console.ReadLine(), out ulong from))
{
    Console.WriteLine("Invalid Input");
    Console.ReadKey();
    return;
}

Console.WriteLine("Enter radix: ");
if (!int.TryParse(Console.ReadLine(), out int radix))
{
    Console.WriteLine("Invalid Input");
    Console.ReadKey();
    return;
}

if (NextPalindrome(from, radix, out result))
{
    Console.WriteLine($"Num {from} in base " + radix + " is a palindrome");
    Console.WriteLine("Palindrome: " + result);

}
else
{
    Console.WriteLine($"Num {from} in base " + radix + " is not a palindrome");

}

Console.ReadKey();

bool NextPalindrome(ulong from, int radix, out ulong result)
{

    if (radix is < 2 or > 32)
    {
        result = 0;
        return false;
    }

    string num = "";

    while (from > 0)
    {
        ulong remainder = from % (ulong)radix;
        char digit;
        digit = remainder < 10 ? (char)('0' + remainder) : (char)('A' + remainder - 10);
        num += digit;
        from /= (ulong)radix;

    }

    string numReversed = new string(num.Reverse().ToArray());

    if (num == numReversed)
    {
        result = ulong.Parse(num);
        return true;
    }



    result = 0;
    return false;
}