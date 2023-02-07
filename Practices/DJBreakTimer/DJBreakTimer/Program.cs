// See https://aka.ms/new-console-template for more information

int breakLengthAsNumber;
TimeSpan songLengthAsTimeSpan;

while (true)
{
    Console.WriteLine("How many mintues is your break: ");
    var breakLength = Console.ReadLine();
    if (int.TryParse(breakLength, out breakLengthAsNumber))
    {
        break;
    }
}

breakLengthAsNumber *= 60; 

while (true)
{
    Console.WriteLine("How long is the song (minutes:seconds): ");
    var songLength = "00:" + Console.ReadLine();
    if (TimeSpan.TryParse(songLength, out songLengthAsTimeSpan))
    {
        break;
    }
}

Thread.Sleep(3000);

var totalMinutesSong = songLengthAsTimeSpan.Minutes;
var totalSecondsSong = songLengthAsTimeSpan.Seconds; 

totalMinutesSong *= 60; 
var beginSongTime = breakLengthAsNumber - totalMinutesSong - totalSecondsSong; 

var minutesLeft = beginSongTime / 60;
var secondsLeft = beginSongTime % 60; 

Console.WriteLine("\n" + DateTime.Now + " is the start of your break.");
var currentTime = DateTime.Now; 

//currentTime.AddMinutes(minutesLeft);
//currentTime.AddSeconds(secondsLeft); 
Console.WriteLine("Start the song after " + minutesLeft + " minutes and " + secondsLeft + " seconds.");
//Console.WriteLine("\nYou should start your song at " + currentTime.AddMinutes(minutesLeft) + ":" + currentTime.AddSeconds(secondsLeft));