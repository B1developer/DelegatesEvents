// Delegate example
public delegate void Logger(string message);  // Declaring a delegate

public class Program
{
    // Methods to be assigned to the delegate
    public static void LogToConsole(string message)
    {
        Console.WriteLine("Log to Console: " + message);
    }

    public static void LogToFile(string message)
    {
        // Simulate writing to a file
        Console.WriteLine("Log to File: " + message);
    }

    // Event-driven button example using a delegate
    public class Button
    {
        public delegate void ClickHandler();  // Declare a delegate for the event
        public event ClickHandler OnClick;    // Declare an event using the delegate

        public void Click()
        {
            Console.WriteLine("Button clicked.");
            if (OnClick != null)
            {
                OnClick();  // Raise the event
            }
        }
    }

    public static void ButtonClicked()
    {
        Console.WriteLine("Button was clicked! Responding to event...");
    }

    // TemperatureSensor example using an event
    public delegate void TemperatureExceededEventHandler(int currentTemperature);  // Declare a delegate for the event

    public class TemperatureSensor
    {
        public event TemperatureExceededEventHandler OnTemperatureExceeded;  // Declare an event

        private int temperature;

        public void SetTemperature(int newTemperature)
        {
            temperature = newTemperature;
            Console.WriteLine($"Temperature set to {temperature} degrees.");

            if (temperature > 30)
            {
                // Raise the event if the temperature exceeds the threshold
                OnTemperatureExceeded?.Invoke(temperature);
            }
        }
    }

    public class AlarmSystem
    {
        public void OnTemperatureExceeded(int currentTemperature)
        {
            Console.WriteLine($"ALARM: Temperature has exceeded safe limit! Current Temperature: {currentTemperature} degrees.");
        }
    }

    static void Main(string[] args)
    {
        // Part 1: Demonstrating delegates
        Console.WriteLine("Delegate Example:");
        Logger log = LogToConsole;  // Assign method to delegate
        log("This is a message for the console");  // Invoke delegate

        log = LogToFile;  // Reassign delegate to a different method
        log("This is a message for the file");  // Invoke delegate

        // Part 2: Event-driven programming example with button
        Console.WriteLine("\nEvent Example with Button:");
        Button button = new Button();
        button.OnClick += ButtonClicked;  // Subscribe to the event
        button.Click();  // Simulate clicking the button

        // Part 3: Temperature sensor event example
        Console.WriteLine("\nTemperature Sensor Event Example:");
        TemperatureSensor sensor = new TemperatureSensor();
        AlarmSystem alarm = new AlarmSystem();

        sensor.OnTemperatureExceeded += alarm.OnTemperatureExceeded;  // Subscribe to the event

        // Set different temperatures to trigger the event
        sensor.SetTemperature(25);  // No alarm
        sensor.SetTemperature(35);  // Alarm triggered
    }
}
