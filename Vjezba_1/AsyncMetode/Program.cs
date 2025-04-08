Console.WriteLine("Zadatak 1.14");

var task1 = CreateSleepTask("task 1", 1000);
var task2 = CreateSleepTask("task 2", 1500);

Task.WaitAll(task1, task2);
async Task CreateSleepTask(string name, int milliSeconds)
{
	Console.WriteLine($"{name} started sleeping");
	await Task.Delay(milliSeconds);
	Console.WriteLine($"{name} finished sleeping");
}


//--------------------------------------------------------------------------------------------

Console.WriteLine("Zadatak 1.15");

await SleepF1();

async Task SleepF1()
{
	Console.WriteLine("SleepF1 started");
	await SleepF2();
	Console.WriteLine("SleepF1 started sleeping");
	await Task.Delay(700);
	Console.WriteLine("SleepF1 finished sleeping");
}

async Task SleepF2()
{
	Console.WriteLine("SleepF2 started");
	Console.WriteLine("SleepF2 started sleeping");
	await Task.Delay(1000);
	Console.WriteLine("SleepF2 finished sleeping");
}
