using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");


const string myPersonalID = "25c2f5d129b24ac7400edbb05ca840b9d90660b2492da77a890ff1821c242b0f";
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/";
const string taskEndpoint = "task/";


HttpUtils httpUtils = HttpUtils.instance;


Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); 
string taskID = "psu31_4"; 


Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine(task1Response);

Console.WriteLine(myPersonalID);
Console.WriteLine(taskID);

string[] input = task1.parameters.Split(",");
int answer = Add(input);

static int Add(string[] numbers)
    {
    int sum = 0;
    foreach (string number in numbers)
    {
        sum += int.Parse(number.Trim());
    }

    return sum;
}
Console.WriteLine($"{answer}\n{myPersonalID}\n{taskID}");
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task1AnswerResponse}{ANSICodes.Reset}");

taskID = "kuTw53L"; 


Console.WriteLine("\n-----------------------------------\n");

Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);

Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task2?.title}{ANSICodes.Reset}\n{task2?.description}\nParameters: {Colors.Yellow}{task2?.parameters}{ANSICodes.Reset}");

string[] input2 = task2.parameters.Split(",");
string answer2 = Prime(input2);

static string Prime(string[] numbers)
{
    List<int> primes = new List<int>();
        foreach (string number in numbers)
        {
            if (IsPrime(int.Parse(number)))
            {
                primes.Add(int.Parse(number));
            }
        }
    primes.Sort();
    return string.Join(",", primes);
}
static bool IsPrime(int number)
{
    if (number <= 1)
        return false;
    if (number <= 3)
        return true;
    if (number % 2 == 0 || number % 3 == 0)
        return false;

    int divisor = 5;
    while (divisor * divisor <= number)
    {
        if (number % divisor == 0 || number % (divisor + 2) == 0)
            return false;
        divisor += 6;
    }
    return true;
}

Console.WriteLine(answer2);
Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer2);
Console.WriteLine($"\nAnswer: {Colors.Green}{task2AnswerResponse}{ANSICodes.Reset}");

taskID = "aAaa23"; 


Console.WriteLine("\n-----------------------------------\n");

Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task3 = JsonSerializer.Deserialize<Task>(task3Response.content);

Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task3?.title}{ANSICodes.Reset}\n{task3?.description}\nParameters: {Colors.Yellow}{task3?.parameters}{ANSICodes.Reset}");

float fahrenheit = float.Parse(task3.parameters);
float Celsius = (fahrenheit - 32) * 5 / 9;
decimal answer3 = Math.Round((decimal)Celsius, 2);
string formattedAnswer3 = answer3.ToString("0.00");

Console.WriteLine(answer3);



Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer3.ToString());
Console.WriteLine($"\nAnswer: {Colors.Green}{task3AnswerResponse}{ANSICodes.Reset}");

taskID = "aLp96"; 


Console.WriteLine("\n-----------------------------------\n");

Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task4 = JsonSerializer.Deserialize<Task>(task4Response.content);

Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task4?.title}{ANSICodes.Reset}\n{task4?.description}\nParameters: {Colors.Yellow}{task4?.parameters}{ANSICodes.Reset}");

class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}