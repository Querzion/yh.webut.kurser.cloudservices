/* RECEIVER */
using Azure.Messaging.ServiceBus;

#region QUEUE

    // var connectionString = "Endpoint=sb://ventixe-assignment-slisk-sbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8IinLH+B+hPhc2cQk4SUE8EaxJ6Q+zlBR+ASbNy/JIQ=";
    // var queueName = "email-service";
    //
    // var client = new ServiceBusClient(connectionString);
    // var processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
    //
    // processor.ProcessMessageAsync += async args =>
    // {
    //     var body = args.Message.Body.ToString();
    //     Console.WriteLine("Received: " + body);
    //     await args.CompleteMessageAsync(args.Message);
    // };
    //
    // processor.ProcessErrorAsync += args =>
    // {
    //     Console.WriteLine($"Error: {args.Exception}");
    //     return Task.CompletedTask;
    // };
    //
    // await processor.StartProcessingAsync();
    // Console.ReadKey();

#endregion

#region TOPIC

    var connectionString = "Endpoint=sb://ventixe-assignment-slisk-sbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8IinLH+B+hPhc2cQk4SUE8EaxJ6Q+zlBR+ASbNy/JIQ=";
    var topicName = "email-service";

    var client = new ServiceBusClient(connectionString);
    var processor = client.CreateProcessor(topicName, new ServiceBusProcessorOptions());

    processor.ProcessMessageAsync += async args =>
    {
        var body = args.Message.Body.ToString();
        Console.WriteLine("Received: " + body);
        await args.CompleteMessageAsync(args.Message);
    };

    processor.ProcessErrorAsync += args =>
    {
        Console.WriteLine($"Error: {args.Exception}");
        return Task.CompletedTask;
    };

    await processor.StartProcessingAsync();
    Console.ReadKey();

#endregion