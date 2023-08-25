using ConsoleApp1;

Console.WriteLine("INIT");
var list = new List<string>
{
    "a",
    "e",
    "i",
    "o",
    "u"
};

var n = "38a";
for (int i = 0; i < 101; i++)  
{ 
    foreach (var item in list)
    { 
        var request = new Helper();

        var result = await request.SenderAsync(i + item);
        result = await request.SenderAsync(item + i);

        if (result == 200)
        {
            Console.WriteLine("BLUM");
        }
        else
        {
            Console.WriteLine("Errou");
        }
        
    }
}




Console.ReadLine();