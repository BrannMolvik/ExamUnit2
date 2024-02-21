﻿using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = "25c2f5d129b24ac7400edbb05ca840b9d90660b2492da77a890ff1821c242b0f"; // GET YOUR PERSONAL ID FROM THE ASSIGNMENT PAGE https://mm-203-module-2-server.onrender.com/
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; // baseURl + startEndpoint + myPersonalID
const string taskEndpoint = "task/";   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
// We start by registering and getting the first task
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); // Print the response from the server to the console
string taskID = "psu31_4"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

//#### FIRST TASK 
// Fetch the details of the task from the server.
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine(task1Response);



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
Console.WriteLine(answer);
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task1AnswerResponse}{ANSICodes.Reset}");

taskID = "kuTw53L"; 


Console.WriteLine("\n-----------------------------------\n");

Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
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

Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task3 = JsonSerializer.Deserialize<Task>(task3Response.content);

Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task3?.title}{ANSICodes.Reset}\n{task3?.description}\nParameters: {Colors.Yellow}{task3?.parameters}{ANSICodes.Reset}");



class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}