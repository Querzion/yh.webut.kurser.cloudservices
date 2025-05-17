/* PUBLISHER */
using Azure.Messaging.ServiceBus;

#region QUEUE

    // var connectionString = "Endpoint=sb://ventixe-assignment-slisk-sbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8IinLH+B+hPhc2cQk4SUE8EaxJ6Q+zlBR+ASbNy/JIQ=";
    // var queueName = "email-service";
    //
    // var client = new ServiceBusClient(connectionString);
    // var sender = client.CreateSender(queueName);
    //
    // Console.WriteLine("Press any key to send message.");
    // Console.ReadKey();
    //
    // var message = new ServiceBusMessage("slisk.lindqvist@querzion.com");
    // await sender.SendMessageAsync(message);
    //
    // await sender.DisposeAsync();
    // await client.DisposeAsync();
    //
    // Console.ReadKey();

#endregion

#region TOPIC

    var connectionString = "Endpoint=sb://ventixe-assignment-slisk-sbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8IinLH+B+hPhc2cQk4SUE8EaxJ6Q+zlBR+ASbNy/JIQ=";
    var topicName = "account-created";

    var client = new ServiceBusClient(connectionString);
    var sender = client.CreateSender(topicName);

    Console.WriteLine("Press any key to send message.");
    Console.ReadKey();

    var message = new ServiceBusMessage("slisk.lindqvist@querzion.com");
    // Doesn't need to be here, it's an added property.
    message.ApplicationProperties.Add("accountType", "admin");
    
    await sender.SendMessageAsync(message);

    await sender.DisposeAsync();
    await client.DisposeAsync();

    Console.ReadKey();

#endregion